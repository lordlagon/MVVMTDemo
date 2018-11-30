using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace AppFarmacia.Behaviors
{
    public class CpfFormatterBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += OnTextChanged;

            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= OnTextChanged;

            base.OnDetachingFrom(bindable);
        }

        void OnTextChanged(object sender, TextChangedEventArgs args)
        {
            var entry = (Entry)sender;
            entry.Text = FormatCpf(entry.Text);

        }

        private string FormatCpf(string input)
        {
            var digitsRegex = new Regex(@"[^\d]");
            var digits = digitsRegex.Replace(input, "");

            if (digits.Length <= 3)
                return digits;

            if (digits.Length <= 6)
                return $"{digits.Substring(0, 3)}.{digits.Substring(3)}";

            if (digits.Length <= 9)
                return $"{digits.Substring(0, 3)}.{digits.Substring(3, 3)}.{digits.Substring(6)}";

            if (digits.Length <= 11)
                return $"{digits.Substring(0, 3)}.{digits.Substring(3, 3)}.{digits.Substring(6, 3)}-{digits.Substring(9)}";

            return $"{digits.Substring(0, 3)}.{digits.Substring(3, 3)}.{digits.Substring(6, 3)}-{digits.Substring(9, 2)}";
        }
    }
}
