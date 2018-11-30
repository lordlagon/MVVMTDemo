using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace AppFarmacia.ViewModels
{
	public class LoyaltyCardPageViewModel : BindableBase
	{
        private ZXingBarcodeImageView _barcode;
        public ZXingBarcodeImageView Barcode
        {
            get { return _barcode; }
            set { SetProperty(ref _barcode, value); }
        }

        public LoyaltyCardPageViewModel()
        {

            Barcode = new ZXingBarcodeImageView
            {
                BarcodeValue = "19872421"
            };
            Barcode.BarcodeOptions.Width = 300;
            Barcode.BarcodeOptions.Height = 300;
            Barcode.BarcodeOptions.Margin = 10;
            Barcode.BarcodeOptions.PureBarcode = true;


        }
	}
}
