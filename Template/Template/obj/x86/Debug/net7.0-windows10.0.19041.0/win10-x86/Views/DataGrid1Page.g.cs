﻿#pragma checksum "C:\Users\ASUS\OneDrive\Documents\GitHub\salemanagers\Template\Template\Views\DataGrid1Page.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A6C17EBF8BF7DF77BB4EF5EECAB60895AB82DE1D3692C51C3517DAF2A9EC3C34"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Template.Views
{
    partial class DataGrid1Page : 
        global::Microsoft.UI.Xaml.Controls.Page, 
        global::Microsoft.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 1.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_CommunityToolkit_WinUI_UI_Controls_DataGrid_ItemsSource(global::CommunityToolkit.WinUI.UI.Controls.DataGrid obj, global::System.Collections.IEnumerable value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Collections.IEnumerable) global::Microsoft.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Collections.IEnumerable), targetNullValue);
                }
                obj.ItemsSource = value;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 1.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class DataGrid1Page_obj1_Bindings :
            global::Microsoft.UI.Xaml.Markup.IDataTemplateComponent,
            global::Microsoft.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Microsoft.UI.Xaml.Markup.IComponentConnector,
            IDataGrid1Page_Bindings
        {
            private global::Template.Views.DataGrid1Page dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::CommunityToolkit.WinUI.UI.Controls.DataGrid obj3;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj3ItemsSourceDisabled = false;

            private DataGrid1Page_obj1_BindingsTracking bindingsTracking;

            public DataGrid1Page_obj1_Bindings()
            {
                this.bindingsTracking = new DataGrid1Page_obj1_BindingsTracking(this);
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 160 && columnNumber == 21)
                {
                    isobj3ItemsSourceDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 3: // Views\DataGrid1Page.xaml line 155
                        this.obj3 = global::WinRT.CastExtensions.As<global::CommunityToolkit.WinUI.UI.Controls.DataGrid>(target);
                        break;
                    default:
                        break;
                }
            }
                        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 1.0.0.0")]
                        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
                        public global::Microsoft.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target) 
                        {
                            return null;
                        }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
            }

            public void Recycle()
            {
                return;
            }

            // IDataGrid1Page_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
                this.bindingsTracking.ReleaseAllListeners();
                this.initialized = false;
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                this.bindingsTracking.ReleaseAllListeners();
                if (newDataRoot != null)
                {
                    this.dataRoot = global::WinRT.CastExtensions.As<global::Template.Views.DataGrid1Page>(newDataRoot);
                    return true;
                }
                return false;
            }

            public void Activated(object obj, global::Microsoft.UI.Xaml.WindowActivatedEventArgs data)
            {
                this.Initialize();
            }

            public void Loading(global::Microsoft.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::Template.Views.DataGrid1Page obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel(obj.ViewModel, phase);
                    }
                }
            }
            private void Update_ViewModel(global::Template.ViewModels.DataGrid1ViewModel obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_ViewModel(obj);
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel_Source(obj.Source, phase);
                    }
                }
            }
            private void Update_ViewModel_Source(global::System.Collections.ObjectModel.ObservableCollection<global::Template.Core.Models.Order> obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_ViewModel_Source(obj);
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // Views\DataGrid1Page.xaml line 155
                    if (!isobj3ItemsSourceDisabled)
                    {
                        XamlBindingSetters.Set_CommunityToolkit_WinUI_UI_Controls_DataGrid_ItemsSource(this.obj3, obj, null);
                    }
                }
            }

            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 1.0.0.0")]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private class DataGrid1Page_obj1_BindingsTracking
            {
                private global::System.WeakReference<DataGrid1Page_obj1_Bindings> weakRefToBindingObj; 

                public DataGrid1Page_obj1_BindingsTracking(DataGrid1Page_obj1_Bindings obj)
                {
                    weakRefToBindingObj = new global::System.WeakReference<DataGrid1Page_obj1_Bindings>(obj);
                }

                public DataGrid1Page_obj1_Bindings TryGetBindingObject()
                {
                    DataGrid1Page_obj1_Bindings bindingObject = null;
                    if (weakRefToBindingObj != null)
                    {
                        weakRefToBindingObj.TryGetTarget(out bindingObject);
                        if (bindingObject == null)
                        {
                            weakRefToBindingObj = null;
                            ReleaseAllListeners();
                        }
                    }
                    return bindingObject;
                }

                public void ReleaseAllListeners()
                {
                    UpdateChildListeners_ViewModel(null);
                    UpdateChildListeners_ViewModel_Source(null);
                }

                public void PropertyChanged_ViewModel(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    DataGrid1Page_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        string propName = e.PropertyName;
                        global::Template.ViewModels.DataGrid1ViewModel obj = sender as global::Template.ViewModels.DataGrid1ViewModel;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                            if (obj != null)
                            {
                                bindings.Update_ViewModel_Source(obj.Source, DATA_CHANGED);
                            }
                        }
                        else
                        {
                            switch (propName)
                            {
                                case "Source":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ViewModel_Source(obj.Source, DATA_CHANGED);
                                    }
                                    break;
                                }
                                default:
                                    break;
                            }
                        }
                    }
                }
                private global::Template.ViewModels.DataGrid1ViewModel cache_ViewModel = null;
                public void UpdateChildListeners_ViewModel(global::Template.ViewModels.DataGrid1ViewModel obj)
                {
                    if (obj != cache_ViewModel)
                    {
                        if (cache_ViewModel != null)
                        {
                            ((global::System.ComponentModel.INotifyPropertyChanged)cache_ViewModel).PropertyChanged -= PropertyChanged_ViewModel;
                            cache_ViewModel = null;
                        }
                        if (obj != null)
                        {
                            cache_ViewModel = obj;
                            ((global::System.ComponentModel.INotifyPropertyChanged)obj).PropertyChanged += PropertyChanged_ViewModel;
                        }
                    }
                }
                public void PropertyChanged_ViewModel_Source(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    DataGrid1Page_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        string propName = e.PropertyName;
                        global::System.Collections.ObjectModel.ObservableCollection<global::Template.Core.Models.Order> obj = sender as global::System.Collections.ObjectModel.ObservableCollection<global::Template.Core.Models.Order>;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                        }
                        else
                        {
                            switch (propName)
                            {
                                default:
                                    break;
                            }
                        }
                    }
                }
                public void CollectionChanged_ViewModel_Source(object sender, global::System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
                {
                    DataGrid1Page_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        global::System.Collections.ObjectModel.ObservableCollection<global::Template.Core.Models.Order> obj = sender as global::System.Collections.ObjectModel.ObservableCollection<global::Template.Core.Models.Order>;
                    }
                }
                private global::System.Collections.ObjectModel.ObservableCollection<global::Template.Core.Models.Order> cache_ViewModel_Source = null;
                public void UpdateChildListeners_ViewModel_Source(global::System.Collections.ObjectModel.ObservableCollection<global::Template.Core.Models.Order> obj)
                {
                    if (obj != cache_ViewModel_Source)
                    {
                        if (cache_ViewModel_Source != null)
                        {
                            ((global::System.ComponentModel.INotifyPropertyChanged)cache_ViewModel_Source).PropertyChanged -= PropertyChanged_ViewModel_Source;
                            ((global::System.Collections.Specialized.INotifyCollectionChanged)cache_ViewModel_Source).CollectionChanged -= CollectionChanged_ViewModel_Source;
                            cache_ViewModel_Source = null;
                        }
                        if (obj != null)
                        {
                            cache_ViewModel_Source = obj;
                            ((global::System.ComponentModel.INotifyPropertyChanged)obj).PropertyChanged += PropertyChanged_ViewModel_Source;
                            ((global::System.Collections.Specialized.INotifyCollectionChanged)obj).CollectionChanged += CollectionChanged_ViewModel_Source;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 1.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Views\DataGrid1Page.xaml line 11
                {
                    this.ContentArea = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.Grid>(target);
                }
                break;
            case 3: // Views\DataGrid1Page.xaml line 155
                {
                    this.tablegridlist = global::WinRT.CastExtensions.As<global::CommunityToolkit.WinUI.UI.Controls.DataGrid>(target);
                }
                break;
            case 5: // Views\DataGrid1Page.xaml line 39
                {
                    global::Microsoft.UI.Xaml.Controls.AutoSuggestBox element5 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.AutoSuggestBox>(target);
                    ((global::Microsoft.UI.Xaml.Controls.AutoSuggestBox)element5).QuerySubmitted += this.AutoSuggestBox_QuerySubmitted;
                    ((global::Microsoft.UI.Xaml.Controls.AutoSuggestBox)element5).SuggestionChosen += this.AutoSuggestBox_SuggestionChosen;
                    ((global::Microsoft.UI.Xaml.Controls.AutoSuggestBox)element5).TextChanged += this.AutoSuggestBox_TextChanged;
                }
                break;
            case 6: // Views\DataGrid1Page.xaml line 48
                {
                    this.EditDialog = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.ContentDialog>(target);
                    ((global::Microsoft.UI.Xaml.Controls.ContentDialog)this.EditDialog).PrimaryButtonClick += this.EditDialog_PrimaryButtonClick;
                    ((global::Microsoft.UI.Xaml.Controls.ContentDialog)this.EditDialog).SecondaryButtonClick += this.EditDialog_SecondaryButtonClick;
                }
                break;
            case 7: // Views\DataGrid1Page.xaml line 88
                {
                    global::Microsoft.UI.Xaml.Controls.AppBarButton element7 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.AppBarButton>(target);
                    ((global::Microsoft.UI.Xaml.Controls.AppBarButton)element7).Click += this.OpenClick;
                }
                break;
            case 8: // Views\DataGrid1Page.xaml line 92
                {
                    global::Microsoft.UI.Xaml.Controls.AppBarButton element8 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.AppBarButton>(target);
                    ((global::Microsoft.UI.Xaml.Controls.AppBarButton)element8).Click += this.ADD_Click;
                }
                break;
            case 9: // Views\DataGrid1Page.xaml line 96
                {
                    global::Microsoft.UI.Xaml.Controls.AppBarButton element9 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.AppBarButton>(target);
                    ((global::Microsoft.UI.Xaml.Controls.AppBarButton)element9).Click += this.DeleteClick;
                }
                break;
            case 10: // Views\DataGrid1Page.xaml line 100
                {
                    global::Microsoft.UI.Xaml.Controls.AppBarButton element10 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.AppBarButton>(target);
                    ((global::Microsoft.UI.Xaml.Controls.AppBarButton)element10).Click += this.Edit_Click;
                }
                break;
            case 11: // Views\DataGrid1Page.xaml line 104
                {
                    global::Microsoft.UI.Xaml.Controls.AppBarButton element11 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.AppBarButton>(target);
                    ((global::Microsoft.UI.Xaml.Controls.AppBarButton)element11).Click += this.SaveClick;
                }
                break;
            case 12: // Views\DataGrid1Page.xaml line 109
                {
                    global::Microsoft.UI.Xaml.Controls.AppBarButton element12 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.AppBarButton>(target);
                    ((global::Microsoft.UI.Xaml.Controls.AppBarButton)element12).Click += this.ADD_Click;
                }
                break;
            case 13: // Views\DataGrid1Page.xaml line 117
                {
                    global::Microsoft.UI.Xaml.Controls.AppBarButton element13 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.AppBarButton>(target);
                    ((global::Microsoft.UI.Xaml.Controls.AppBarButton)element13).Click += this.DeleteClick;
                }
                break;
            case 14: // Views\DataGrid1Page.xaml line 125
                {
                    global::Microsoft.UI.Xaml.Controls.AppBarButton element14 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.AppBarButton>(target);
                    ((global::Microsoft.UI.Xaml.Controls.AppBarButton)element14).Click += this.SaveClick;
                }
                break;
            case 15: // Views\DataGrid1Page.xaml line 57
                {
                    this.EditNameTextBox = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBox>(target);
                }
                break;
            case 16: // Views\DataGrid1Page.xaml line 62
                {
                    this.EditCustomerTextBox = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBox>(target);
                }
                break;
            case 17: // Views\DataGrid1Page.xaml line 67
                {
                    this.EditDateTextBox = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.DatePicker>(target);
                }
                break;
            case 18: // Views\DataGrid1Page.xaml line 68
                {
                    this.EditItemTextBox = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBox>(target);
                }
                break;
            case 19: // Views\DataGrid1Page.xaml line 73
                {
                    this.EditCountTextBox = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.TextBox>(target);
                }
                break;
            case 20: // Views\DataGrid1Page.xaml line 25
                {
                    global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem element20 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem>(target);
                    ((global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem)element20).Click += this.MenuFlyoutItem_Click;
                }
                break;
            case 21: // Views\DataGrid1Page.xaml line 30
                {
                    global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem element21 = global::WinRT.CastExtensions.As<global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem>(target);
                    ((global::Microsoft.UI.Xaml.Controls.MenuFlyoutItem)element21).Click += this.MenuFlyoutItem_Click_1;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.UI.Xaml.Markup.Compiler"," 1.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Microsoft.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Microsoft.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1: // Views\DataGrid1Page.xaml line 1
                {                    
                    global::Microsoft.UI.Xaml.Controls.Page element1 = (global::Microsoft.UI.Xaml.Controls.Page)target;
                    DataGrid1Page_obj1_Bindings bindings = new DataGrid1Page_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                    global::Microsoft.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element1, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}

