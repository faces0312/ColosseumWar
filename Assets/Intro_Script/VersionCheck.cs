using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Google.Play.AppUpdate;
using Google.Play.Common;

public class VersionCheck : MonoBehaviour
{
    AppUpdateManager appUpdateManager;

    private void Start()
    {
        StartCoroutine(CheckForUpdate());
    }
    private IEnumerator CheckForUpdate()
    {
        PlayAsyncOperation<AppUpdateInfo, AppUpdateErrorCode> appUpdateInfoOperation =
            appUpdateManager.GetAppUpdateInfo();

        //wait unitll
        yield return appUpdateInfoOperation;

        if(appUpdateInfoOperation.IsSuccessful)
        {
            var appUpdateInforResult = appUpdateInfoOperation.GetResult();

            var appUpdateOption = AppUpdateOptions.ImmediateAppUpdateOptions();
            StartCoroutine(StartImmediateAppUpdate(appUpdateInforResult, appUpdateOption));
        }
    }

    IEnumerator StartImmediateAppUpdate(AppUpdateInfo appUpdateInfoOp_i,AppUpdateOptions appUpdateOptions_i)
    {
        var startUpdateRequest = appUpdateManager.StartUpdate(
            appUpdateInfoOp_i, appUpdateOptions_i
            );

        yield return startUpdateRequest;
    }
}
