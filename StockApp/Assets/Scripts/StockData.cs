public class StockData {

    public enum DurationEnum
    {
        Long, 
        Middle, 
        Short
    }

    public string stockID;
    public float marketPrice;
    public float targetPrice;
    public float stopPrice;

    public DurationEnum duration;
    public string reasonToBuy;

    public StockData(string _id, float mPrice, float tPrice, float sPrice, DurationEnum _duration, string _reason)
    {
        stockID = _id;
        marketPrice = mPrice;
        targetPrice = tPrice;
        stopPrice = sPrice;
        duration = _duration;
        reasonToBuy = _reason;
    }
}
