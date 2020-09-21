# Plugin.BottomSheet
Bottom Sheet implementation for Xamarin Forms


# Getting Started

- Install nuget package to your portable layer. You can find it from [here](https://www.nuget.org/packages/Plugin.BottomSheet)

- Go your XAML page and add following namespace

```xml
xmlns:bs="clr-namespace:Plugin.BottomSheet;assembly=Plugin.BottomSheet"
```

- Then place **BottomSheetLayout** at the root of your Page

```xml
<bs:BottomSheetLayout>
    <StackLayout>
        <Label Text="Your Page Content here..."/>
    </StackLayout>

    <bs:BottomSheetLayout.BottomSheetContent>
        <StackLayout BackgroundColor="WhiteSmoke">
             <Label Text="Your BottomPage Content here..."/>
        </StackLayout>
    </bs:BottomSheetLayout.BottomSheetContent>
</bs:BottomSheetLayout>
```

# Showcase

![video-1600725616](https://user-images.githubusercontent.com/23705418/93826077-27f29480-fc6f-11ea-947d-caa44d6dfcf2.gif)
