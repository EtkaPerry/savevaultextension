using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Media;
using SaveVaultApp.Views;

namespace SaveVaultApp.Extensions.TestButtonExtension
{
    /// <summary>
    /// Main entry point for the Test Button Extension
    /// </summary>
    public class TestButtonExtensionMain
    {
        private MenuItem? _testButton;

        /// <summary>
        /// Initialize the extension
        /// </summary>
        public void Initialize()
        {
            try
            {
                // Subscribe to main window loaded event
                App.Current.MainWindow.Loaded += MainWindow_Loaded;
                Console.WriteLine("Test Button Extension initialized successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing Test Button Extension: {ex.Message}");
            }
        }

        /// <summary>
        /// Handle main window loaded event
        /// </summary>
        private void MainWindow_Loaded(object? sender, EventArgs e)
        {
            try
            {
                if (App.Current.MainWindow is MainWindow mainWindow)
                {
                    // Find the main menu where Tools is located
                    var menuBar = mainWindow.FindControl<Menu>("TitleBar")?.FindControl<Menu>(null);
                    if (menuBar != null)
                    {
                        // Create test button
                        _testButton = new MenuItem
                        {
                            Header = "Test Button",
                            Icon = CreateTestIcon()
                        };

                        // Add command handler
                        _testButton.Click += TestButton_Click;

                        // Add to menu after Tools
                        bool toolsFound = false;
                        for (int i = 0; i < menuBar.Items.Count; i++)
                        {
                            if (menuBar.Items[i] is MenuItem menuItem && menuItem.Header.ToString() == "Tools")
                            {
                                toolsFound = true;
                                menuBar.Items.Insert(i + 1, _testButton);
                                break;
                            }
                        }

                        // If Tools not found, add at the end
                        if (!toolsFound)
                        {
                            menuBar.Items.Add(_testButton);
                        }

                        Console.WriteLine("Test Button added to menu bar");
                    }
                    else
                    {
                        Console.WriteLine("Could not find menu bar in main window");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding Test Button: {ex.Message}");
            }
        }

        /// <summary>
        /// Handle test button click
        /// </summary>
        private async void TestButton_Click(object? sender, EventArgs e)
        {
            try
            {
                // Show a simple message dialog
                var dialog = new Avalonia.Controls.Window
                {
                    Title = "Test Button Extension",
                    SizeToContent = SizeToContent.WidthAndHeight,
                    WindowStartupLocation = WindowStartupLocation.CenterOwner,
                    MinWidth = 300,
                    MinHeight =
                    200
                };

                var grid = new Grid();
                grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
                grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

                var textBlock = new TextBlock
                {
                    Text = "Test Button Extension is working!",
                    TextWrapping = TextWrapping.Wrap,
                    HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
                    VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center,
                    Margin = new Avalonia.Thickness(20, 20, 20, 20)
                };

                var closeButton = new Button
                {
                    Content = "Close",
                    HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
                    Margin = new Avalonia.Thickness(0, 0, 0, 20),
                    Padding = new Avalonia.Thickness(20, 10, 20, 10)
                };

                closeButton.Click += (s, args) => dialog.Close();

                Grid.SetRow(textBlock, 0);
                Grid.SetRow(closeButton, 1);

                grid.Children.Add(textBlock);
                grid.Children.Add(closeButton);

                dialog.Content = grid;

                await dialog.ShowDialog(App.Current.MainWindow);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error handling Test Button click: {ex.Message}");
            }
        }

        /// <summary>
        /// Create a simple icon for the Test Button
        /// </summary>
        private IControl CreateTestIcon()
        {
            try
            {
                // Create a simple icon using PathIcon
                return new Avalonia.Controls.PathIcon
                {
                    Data = Geometry.Parse("M12,2A10,10 0 0,0 2,12A10,10 0 0,0 12,22A10,10 0 0,0 22,12A10,10 0 0,0 12,2M11,16.5L7.5,13L9,11.5L11,13.5L15,9.5L16.5,11L11,16.5Z"),
                    Width = 16,
                    Height = 16
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating Test Button icon: {ex.Message}");
                return new Avalonia.Controls.TextBlock { Text = "T" };
            }
        }

        /// <summary>
        /// Shutdown the extension
        /// </summary>
        public void Shutdown()
        {
            try
            {
                // Remove the test button if it exists
                if (_testButton != null && App.Current.MainWindow is MainWindow mainWindow)
                {
                    var menuBar = mainWindow.FindControl<Menu>("TitleBar")?.FindControl<Menu>(null);
                    if (menuBar != null && menuBar.Items.Contains(_testButton))
                    {
                        menuBar.Items.Remove(_testButton);
                    }
                }

                // Unsubscribe from events
                if (App.Current.MainWindow != null)
                {
                    App.Current.MainWindow.Loaded -= MainWindow_Loaded;
                }

                Console.WriteLine("Test Button Extension shutdown successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error shutting down Test Button Extension: {ex.Message}");
            }
        }
    }
}
