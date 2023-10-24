using Android.Content.PM;
using Android.Runtime;

namespace PM2E147.Droid
{
    public interface IMainActivity
    {
        void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults);
    }
}