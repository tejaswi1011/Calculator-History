using Project1.Themes;

namespace Project1;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
	}

	void OnThemeChange(object sender, EventArgs e)
	{
		MenuItem menuItem = sender as MenuItem;
		string theme = menuItem.Text;

		ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
		if (mergedDictionaries != null)
		{
			mergedDictionaries.Clear();

            switch (theme)
            {
                case "Green":
                    mergedDictionaries.Add(new Green());
                    break;
                case "Pink":
                    mergedDictionaries.Add(new Pink());
                    break;
                case "Dark":
                    mergedDictionaries.Add(new Dark());
                    break;
                case "Light":
                default:
                    mergedDictionaries.Add(new Light());
                    break;
            }
        }

    }
}
