



    public enum AmmoType
    {
        GUN,
        SUBMACHINEGUN,
        RIFFLE
    }

    public struct ammoContent
    {
        AmmoType type;
        int ammo;
    }
    public interface IAmmo
    {
        void AmmoAvailable(int ammo);
        void UpdateAmmo(int ID);

    }


