//
//  ContentView.swift
//  MovieFlix
//
//  Created by LihinduPerera on 2026-09-28.
//

import SwiftUI

struct ContentView: View {
    var body: some View {
        TabView {
            Tab(Constants.homeString, systemImage: Constants.homeIconString) {
                HomeView()
            }
            Tab(Constants.upcommingString, systemImage: Constants.upcommingIconString) {
                UpcommingView()
            }
            Tab(Constants.searchingString, systemImage: Constants.searchingIconString) {
                SearchView()
            }
            Tab(Constants.downloadString, systemImage: Constants.downloadIconString) {
                DownloadView()
            }
        }
    }
}

#Preview {
    ContentView()
}
