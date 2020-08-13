package com.tibixapps.starsync;

import android.os.Bundle;

import com.google.android.material.bottomnavigation.BottomNavigationView;
import com.tibixapps.starsync.ui.history.HistoryFragment;
import com.tibixapps.starsync.ui.home.HomeFragment;
import com.tibixapps.starsync.ui.webdashboard.WebDashboardFragment;
import com.tibixapps.starsync.ui.options.OptionsFragment;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;
import androidx.fragment.app.Fragment;

import android.view.MenuItem;
import android.view.View;

public class StarSyncActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_star_sync);

        BottomNavigationView bottomNav = findViewById(R.id.bottomNavMenu);

        if (savedInstanceState == null) {
            getSupportFragmentManager().beginTransaction().replace(R.id.framelayout_a,
                    new HomeFragment()).commit();
        }
    }

            BottomNavigationView.OnNavigationItemSelectedListener navListener =
                    new BottomNavigationView.OnNavigationItemSelectedListener() {
                        @Override
                        public boolean onNavigationItemSelected(@NonNull MenuItem item) {
                            Fragment selectedFragment = null;
                            switch (item.getItemId()) {
                                case R.id.nav_SyncSaves:
                                    selectedFragment = new HomeFragment();
                                    break;
                                case R.id.nav_SaveHistory:
                                    selectedFragment = new HistoryFragment();
                                    break;
                                case R.id.nav_WebDashboard:
                                    selectedFragment = new WebDashboardFragment();
                                    break;

                                case R.id.nav_Options:
                                    selectedFragment = new OptionsFragment();
                                    break;
                            }
                            getSupportFragmentManager().beginTransaction().replace(R.id.framelayout_a,
                                    selectedFragment).commit();
                            return true;


                        }
                    };
        }

