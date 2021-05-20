using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace ImplicitAnimationBug
{
    public sealed class CustomControl1 : ContentControl
    {
        private Popup _popup;
        public CustomControl1()
        {
            this.DefaultStyleKey = typeof(CustomControl1);
        }

        public async void Show()
        {
            if (_popup == null)
            {
                _popup = new Popup()
                {
                    Child = this,
                    IsLightDismissEnabled = false,
                };
            }

            this._popup.IsOpen = true;
            this.Visibility = Visibility.Visible;
            Debug.WriteLine("[toast] Visible");
            await Task.Delay(3000);
            Debug.WriteLine("[toast] Collapsed");
            this._popup.IsOpen = false;
            this.Visibility = Visibility.Collapsed;
        }

    }
}
