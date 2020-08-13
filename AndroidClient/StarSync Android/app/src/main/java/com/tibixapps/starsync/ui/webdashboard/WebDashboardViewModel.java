package com.tibixapps.starsync.ui.webdashboard;

import androidx.lifecycle.LiveData;
import androidx.lifecycle.MutableLiveData;
import androidx.lifecycle.ViewModel;

public class WebDashboardViewModel extends ViewModel {

    private MutableLiveData<String> mText;

    public WebDashboardViewModel() {
        mText = new MutableLiveData<>();
        mText.setValue("This is notifications fragment");
    }

    public LiveData<String> getText() {
        return mText;
    }
}