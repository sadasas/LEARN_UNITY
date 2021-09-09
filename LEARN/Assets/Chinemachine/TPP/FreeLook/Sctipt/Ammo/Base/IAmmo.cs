

    public enum AmmoType
    {
        GUN,
        SUBMACHINEGUN,
        RIFFLE
    }

    public interface IAmmo
    {
         void OnStart();
        void AmmoAvailable(int ammo);
        void UpdateAmmo(int ID);

    }


