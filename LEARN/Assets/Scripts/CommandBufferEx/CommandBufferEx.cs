
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace NrawangStudio.CommandBufferEx
{


    public class CustomGlowSystem
    {
        static CustomGlowSystem m_Instance;
        static public CustomGlowSystem instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new CustomGlowSystem();
                return m_Instance;
            }
        }

        internal HashSet<CommandBufferObj> m_GlowObjs = new HashSet<CommandBufferObj>();
        public void Add(CommandBufferObj o)
        {
            m_GlowObjs.Add(o);
        }
        public void Remove(CommandBufferObj o)
        {
            m_GlowObjs.Remove(o);
        }
    }

    [ExecuteInEditMode]
    public class CommandBufferEx : MonoBehaviour
    {
        CommandBuffer m_GlowBuffer;
        Dictionary<Camera, CommandBuffer> m_Cameras = new Dictionary<Camera, CommandBuffer>();

        public void Cleanup()
        {
            foreach (var cam in m_Cameras)
            {
                if (cam.Key)
                    cam.Key.RemoveCommandBuffer(CameraEvent.BeforeLighting,cam.Value );
            }
            m_Cameras.Clear();
        }
        private void OnEnable()
        {
            Cleanup();
        }
        public void OnDisable()
        {
            Cleanup();
        }

        public void OnWillRenderObject()
        {
            Debug.Log("lkl");
            var render = gameObject.activeInHierarchy && enabled;
            if (!render)
            {
                Cleanup();
                return;
            }

            var cam = Camera.current;
            if (!cam)
                return;

            if (m_Cameras.ContainsKey(cam))
                return;

            //create new command buffer
            m_GlowBuffer = new CommandBuffer();
            m_GlowBuffer.name = "Glow map buffer";
            m_Cameras[cam] = m_GlowBuffer;

            var glowSystem = CustomGlowSystem.instance;

            // create render texture for glow map
            int tempID = Shader.PropertyToID("_Temp1");
            m_GlowBuffer.GetTemporaryRT(tempID, -1, -1, 24, FilterMode.Bilinear);
            m_GlowBuffer.SetRenderTarget(tempID);
            m_GlowBuffer.ClearRenderTarget(true, true, Color.black); // clear before drawing to it each frame!!

            // draw all glow objects to it
            foreach (CommandBufferObj o in glowSystem.m_GlowObjs)
            {
                Renderer r = o.GetComponent<Renderer>();
                Material glowMat = o.glowMaterial;
                if (r && glowMat)
                    m_GlowBuffer.DrawRenderer(r, glowMat);
            }

            // set render texture as globally accessable 'glow map' texture
            m_GlowBuffer.SetGlobalTexture("_GlowMap", tempID);

            // add this command buffer to the pipeline
            cam.AddCommandBuffer(CameraEvent.BeforeLighting, m_GlowBuffer);
        }
    }
}
