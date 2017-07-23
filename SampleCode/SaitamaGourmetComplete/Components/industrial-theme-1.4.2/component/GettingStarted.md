## Applying the Theme

To style your app with this modern theme, call
`IndustrialTheme.Apply` from your AppDelegate's `FinishedLaunching` method:

```csharp
using Xamarin.Themes;
...

public override bool FinishedLaunching (UIApplication app, NSDictionary options)
{
  IndustrialTheme.Apply ();
  ...
}
```

You can also selectively apply the theme to specific views. To apply the theme
to views of a specific class, call `Apply` with the `Appearance` object for the
view class you'd like themed:

```csharp
IndustrialTheme.Apply (UIProgressView.Appearance);
```

To apply the theme to specific view classes only when they are contained within
other specific view classes, use `AppearanceWhenContainedIn`. In the following
example, we apply `IndustrialTheme` to `UIProgressView` only when
`UIProgressView` is a child of `UINavigationBar`. 

```csharp
IndustrialTheme.Apply (UIProgressView.AppearanceWhenContainedIn (typeof (UINavigationBar)));
```

Finally, to apply the theme only to a specific view instance:

```csharp
UIProgressView progressView;
...

IndustrialTheme.Apply (progressView);
```


```csharp
UITableView tableView;
...

IndustrialTheme.Apply (tableView);
```

When applying a theme to a TableView, you still need to apply the theme to the cells.

```csharp
public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
{
  UITableViewCell cell;
	...
	IndustrialTheme.Apply (cell);
	return cell;
}
```

Applying a theme to specific view instances is especially useful for `UIButton`,
`UILabel`, and `UIView` instances, since they are not themed automatically when
calling the parameterless version of `Apply`.

## Options

The theme can be customized using a string argument passed to the `Apply`
method. In this example, we use the `"confirm"` option to apply a special
confirmation button style to a `UIButton`:

```csharp
IndustrialTheme.Apply (button, "confirm");
```

This theme supports the following options:

* `UIButton`
  - `"confirm"`
  - `"cancel"`
  - `"aluminum"`
  - `"landscape"`
