public class RangePercentage {

    public static float Calculate(float minPercentage, float maxPercentage, float minValue, float maxValue, float currentValue) {
        // float minDateBinary = (float) TimeManager.Instance.InitialDate.ToBinary();
        // float maxDateBinary = (float) TimeManager.Instance.EndDate.ToBinary();
        // float newCurrentBinary = (float) TimeManager.Instance.CurrentDate.ToBinary();
        float percent = (currentValue - minValue) / (maxValue - minValue);
        return percent * (maxPercentage - minPercentage) + minPercentage;
    }

}