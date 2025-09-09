# custom-model-collection-in-.net-maui-aiassistview

This demo demonstartes support for binding collection of custom data objects through the ItemsSource property and allows users to use their own data objects with the control. The ItemsSource property binds a collection of custom data objects to the SfAIAssistView and each item in the collection will be converted to an AssistItem and displayed in the view.

```xaml

    <ContentPage.Resources>
        <ResourceDictionary>
            <local:AssistItemConverter x:Key="converter" />
        </ResourceDictionary>
    </ContentPage.Resources>
    <ContentPage.BindingContext>
        <local:ViewModel x:Name="viewModel" />
    </ContentPage.BindingContext>
    <syncfusion:SfAIAssistView x:Name="assistView"
                               ItemsSource="{Binding AssistItemsCollection}"
                               ItemsSourceConverter="{StaticResource converter}" />

AssistItemConverter :

    public class AssistItemConverter : IAssistItemConverter
    {
        public IAssistItem ConvertToAssistItem(object customItem, SfAIAssistView assistView)
        {
            var assistItem = new AssistItem();
            var item = customItem as ItemModel;
            if (item != null)
            {
                assistItem.Data = item;
                assistItem.IsRequested = item.IsRequested;
                if (item.IsRequested)
                {
                    if (item.Prompt != null)
                    {
                        assistItem.Text = item.Prompt;
                    }
                }
                else
                {
                    if (item.Response != null)
                    {
                        assistItem.Text = item.Response;
                    }
                }
            }
            return assistItem;
        }

        public object ConvertToData(object assistViewItem, SfAIAssistView assistView)
        {
            var item = new ItemModel();
            var assistItem = assistViewItem as AssistItem;
            if (assistItem != null)
            {
                item.IsRequested = assistItem.IsRequested;
                if (item.IsRequested)
                {
                    item.Prompt = assistItem.Text;
                }
                else
                {
                    item.Response = assistItem.Text;
                }
            }
            return item;
        }
    }

```

## Requirements to run the demo

To run the demo, refer to [System Requirements for .NET MAUI](https://help.syncfusion.com/maui/system-requirements)

## Troubleshooting:
### Path too long exception

If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.

## License

Syncfusion® has no liability for any damage or consequence that may arise from using or viewing the samples. The samples are for demonstrative purposes. If you choose to use or access the samples, you agree to not hold Syncfusion® liable, in any form, for any damage related to use, for accessing, or viewing the samples. By accessing, viewing, or seeing the samples, you acknowledge and agree Syncfusion®'s samples will not allow you seek injunctive relief in any form for any claim related to the sample. If you do not agree to this, do not view, access, utilize, or otherwise do anything with Syncfusion®'s samples.
