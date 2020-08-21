namespace Encapsulation
{
    public sealed class Temperature
    {
        private const double AbsoluteZeroInCelsius = -273.15;

        private double _temperatureInCelsius;

        public double TemperatureInCelsius
        {
            get { return _temperatureInCelsius; }
            set
            {
                if (value < AbsoluteZeroInCelsius) return; // Такой температуры не существует, ниже абсолютного нуля температуры
                _temperatureInCelsius = value;
            }
        }

        public double TemperatureInKelvin
        {
            get { return _temperatureInCelsius - AbsoluteZeroInCelsius; }
            set
            {
                if (value < 0) return;
                _temperatureInCelsius = value + AbsoluteZeroInCelsius;
            }
        }

        public double TemperatureInFahrenheit
        {
            get { return 9.0 / 5.0 * _temperatureInCelsius + 32; }
            set
            {
                TemperatureInCelsius = 5.0 / 9.0 * (value - 32);
            }
        }
    }
}
