using System;
using System.Collections.ObjectModel;
using ImageGallery.MVVM;

namespace ImageGallery.ViewModels
{
    public class LicensePageViewModel : ViewModelBase
    {
        public ObservableCollection<LicenseViewModel> ThirdpartyLibraries { get; } = new ObservableCollection<LicenseViewModel>();


        public LicensePageViewModel()
        {
            this.LoadLicenses();
        }

        private void LoadLicenses()
        {
            LicenseViewModel porojectLicense = LicenseViewModel.Create();
            porojectLicense.Title = "Bachelor Thesis 2021 Project Imago";
            porojectLicense.Website = new Uri("https://gitlab.svccomp.de/svccomp-students/bsc-thesis/2021/stefan-zindl");
            porojectLicense.Text = @"
The MIT License (MIT)

Copyright (c) 2021 Stefan Zindl

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the 'Software'), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/ or sell
 copies of the Software, and to permit persons to whom the Software is
 furnished to do so, subject to the following conditions:

            The above copyright notice and this permission notice shall be included in all
            copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED 'AS IS', WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.";

            LicenseViewModel mahIconPacks = LicenseViewModel.Create();
            mahIconPacks.Title = "MahApps.Metro.IconPacks";
            mahIconPacks.Website = new Uri("https://github.com/MahApps/MahApps.Metro.IconPacks");
            mahIconPacks.LastUpdated = new DateTime(2020, 10, 29);
            mahIconPacks.Version = "4.8.0";
            mahIconPacks.Text = @"
The MIT License (MIT)

Copyright (c) 2016-2019 MahApps, Jan Karger

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the 'Software'), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/ or sell
 copies of the Software, and to permit persons to whom the Software is
 furnished to do so, subject to the following conditions:

            The above copyright notice and this permission notice shall be included in all
            copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED 'AS IS', WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.";

            LicenseViewModel mahDesignKit = LicenseViewModel.Create();
            mahDesignKit.Title = "Material Design In XAML Toolkit";
            mahDesignKit.Website = new Uri("https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit");
            mahDesignKit.LastUpdated = new DateTime(2021, 2, 14);
            mahDesignKit.Text = @"
The MIT License (MIT)

Copyright (c) James Willock,  Mulholland Software and Contributors

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the 'Software'), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/ or sell
 copies of the Software, and to permit persons to whom the Software is
 furnished to do so, subject to the following conditions:

            The above copyright notice and this permission notice shall be included in all
            copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED 'AS IS', WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.";

            LicenseViewModel xamlUI = LicenseViewModel.Create();
            xamlUI.Title = "Windows UI Library";
            xamlUI.Website = new Uri("https://github.com/microsoft/microsoft-ui-xaml");
            xamlUI.LastUpdated = new DateTime(2021, 2, 14);
            xamlUI.Text = @"
MIT License

Copyright (c) Microsoft Corporation. All rights reserved.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the 'Software'), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/ or sell
 copies of the Software, and to permit persons to whom the Software is
 furnished to do so, subject to the following conditions:

        The above copyright notice and this permission notice shall be included in all
        copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED 'AS IS', WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE";
            
            this.ThirdpartyLibraries.Add(porojectLicense);
            this.ThirdpartyLibraries.Add(xamlUI);
            this.ThirdpartyLibraries.Add(mahIconPacks);
            this.ThirdpartyLibraries.Add(mahDesignKit);
        }
    }
}
