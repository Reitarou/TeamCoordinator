using System;
using System.ComponentModel;
using System.Globalization;

namespace TeamCoordinator
{
    public enum TeamState
    {
        Pass = -100,
        Pause = -50,
        Incomplete = 0,
        AtOtherScene = 5,
        CallToBase = 10,
        SentToScene = 20,
        StartWork = 50,
        MoveBack = 90,
        Completed = 100,
        Ready = 200,
        Comment = -200,
        Unknown = -1000,
    }

    public sealed class TeamStateEnumConverter : EnumConverter
    {
        public static readonly TeamStateEnumConverter Current = new TeamStateEnumConverter(typeof(TeamState));

        public TeamStateEnumConverter(Type type) : base(type)
        {
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return (destinationType == typeof(string));
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (value is TeamState)
            {
                TeamState x = (TeamState)value;

                switch (x)
                {
                    case TeamState.Pass:
                        return "Этап пропускается";

                    case TeamState.Pause:
                        return "На паузе";

                    case TeamState.Incomplete:
                        return "Этап не выполнен";

                    case TeamState.AtOtherScene:
                        return "На другой сцене";

                    case TeamState.CallToBase:
                        return "Вызвана на базу";

                    case TeamState.SentToScene:
                        return "Отправлена на сцену";

                    case TeamState.StartWork:
                        return "Начала работу";

                    case TeamState.MoveBack:
                        return "Возвращается";

                    case TeamState.Completed:
                        return "Этап выполнен";

                    case TeamState.Ready:
                        return "Готова";

                    case TeamState.Comment:
                        return "Комментарий";

                    case TeamState.Unknown:
                        return "Статус неизвестен";

                    default:
                        throw new NotImplementedException("{x} is not translated. Add it!!!");
                }
            }
            return base.ConvertFrom(context, culture, value);
        }
    }
}