using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Controls
{
    /// <summary>
    /// Общие методы расширений.
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Включение двойной буферизации для контрола
        /// </summary>
        public static void SetDoubleBuffered(this Control control)
        {
            PropertyInfo aProp =
                typeof(Control).GetProperty(
                    "DoubleBuffered",
                    BindingFlags.NonPublic |
                    BindingFlags.Instance);

            aProp?.SetValue(control, true, null);
        }

        /// <summary>
        /// Gets an attribute on an enum field value
        /// </summary>
        /// <typeparam name="T">The type of the attribute you want to retrieve</typeparam>
        /// <param name="enumVal">The enum value</param>
        /// <returns>The attribute of type T that exists on the enum value</returns>
        public static T GetAttribute<T>(this Enum enumVal) where T : Attribute
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return attributes.Length > 0 ? (T)attributes[0] : null;
        }

        /// <summary>
        /// Следующее значение из перечисления
        /// </summary>
        public static T Switch<T>(this T value)
        {
            if (!typeof(T).IsEnum)
            {
                return value;
            }
            var values = ((T[])Enum.GetValues(typeof(T))).Distinct().ToArray();
            for (var i = 0; i < values.Length - 1; i++)
            {
                if (value.Equals(values[i]))
                    return values[i + 1];
            }
            return values[0];
        }

        /// <summary>
        /// Отжимание всех кнопок кроме заданной
        /// </summary>
        /// <param name="strip">Панель, на которой нужно отжать кнопки</param>
        /// <param name="button">Кнопка, которую оставить нажатой</param>
        /// <remarks>Если кнопка задана, то отжимаются все кнопки на панели кроме неё. Если не задана, то все кнопки панели</remarks>
        public static void UncheckButtons(this ToolStrip strip, ToolStripButton button = null)
        {
            //Кнопка не на панели
            if (button != null && !strip.Items.Contains(button))
            {
                throw new ArgumentException("Кнопка должна находиться на панели!");
            }
            var toolStripButtons = button != null
                ? button.GetCurrentParent()
                        .Items.OfType<ToolStripButton>()
                        .Where(b => b.CheckOnClick && !b.Equals(button))
                : strip.Items
                                  .OfType<ToolStripButton>()
                                  .Where(b => b.CheckOnClick);

            foreach (var btn in toolStripButtons)
                btn.Checked = false;
        }
    }
}
