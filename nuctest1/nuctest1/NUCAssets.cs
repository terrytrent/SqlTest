using System;
using System.Threading;
using System.Data.SqlClient;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nuctest1
{
    public enum Statuses
    {
        Available,
        Initial,
        Replacement
    }

    public enum AssetTypes
    {
        Computer,
        HD,
        RAM
    }

    public class storeInfoInDB
    {
        public storeInfoInDB(string message)
        {
            for (int i = 0; i < message.Length; i++)
            {
                Console.Write(message[i]);
                Thread.Sleep(25);
            }
            for (int i = 1; i < message.Length; i++)
            {
                Console.WriteLine(message[i]);
                Thread.Sleep(25);
            }
        }

    }

    public class NUCAsset
    {
        protected string AssetSN;
        protected string AssetModel;
        protected Statuses AssetStatus;
        protected Guid AssetGuid;

        public virtual void getInfo()
        {
            Console.WriteLine($"Asset Serial Number: {AssetSN}\nAsset Model: {AssetModel}\nAsset Status: {AssetStatus.ToString()}\nAsset Guid: {AssetGuid.ToString()}");
        }

        public virtual void setSerialNumber(string SerialNumber)
        {
            AssetSN = SerialNumber;
        }

        public virtual void setModel(string Model)
        {
            AssetModel = Model;
        }

        public virtual void setStatus(Statuses Status)
        {
            AssetStatus = Status;
        }

        public virtual void setInfo(string SerialNumber, string Model, Statuses Status)
        {
            AssetGuid = Guid.NewGuid();
            this.setSerialNumber(SerialNumber);
            this.setModel(Model);
            this.setStatus(Status);
        }

        public virtual void setInfo(string SerialNumber, string Model, Statuses Status, AssetTypes Type, int SizeInGB) { }

        public virtual void storeInfoInDB()
        {
            
        }

    }

    public class NUCAssetComputer : NUCAsset
    {
        private AssetTypes AssetType = AssetTypes.Computer;

        public override void getInfo()
        {

            Console.WriteLine($"Asset Type: {AssetType}");
            base.getInfo();
        }

        public override void storeInfoInDB()
        {
            string message = $"Storing in DB: {AssetSN}, {AssetModel}, {AssetStatus.ToString()}, {AssetType.ToString()}, ";
            storeInfoInDB storeInfo = new storeInfoInDB(message);
        }
    }

    public class NUCAssetStorage : NUCAsset
    {
        private int AssetSizeInGB;
        private AssetTypes AssetType;

        public override void getInfo()
        {
            Console.WriteLine($"Asset Type: {AssetType}\nAsset Size In GB: {AssetSizeInGB}");
            base.getInfo();
        }
        public void setAssetSizeInGB(int SizeInGB)
        {
            AssetSizeInGB = SizeInGB;
        }

        public void setAssetType(AssetTypes Type)
        {
            AssetType = Type;
        }

        public override void setInfo(string SerialNumber, string Model, Statuses Status, AssetTypes Type, int SizeInGB)
        {
            this.setAssetSizeInGB(SizeInGB);
            this.setAssetType(Type);
            base.setInfo(SerialNumber, Model, Status);
        }

        public override void storeInfoInDB()
        {
            string message = $"Storing in DB: {AssetSN}, {AssetModel}, {AssetStatus.ToString()}, {AssetType.ToString()}, {AssetSizeInGB}\n";
            storeInfoInDB storeInfo = new storeInfoInDB(message);
        }
    }
}
