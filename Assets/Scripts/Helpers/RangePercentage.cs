public class RangePercentage {

    public static float Calculate(float minPercentage, float maxPercentage, float minValue, float maxValue, float currentValue) {
        float percent = (currentValue - minValue) / (maxValue - minValue);
        return percent * (maxPercentage - minPercentage) + minPercentage;
    }

}