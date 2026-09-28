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
            Text(Constants.homeString)
                .tabItem {
                    Label(Constants.homeString, systemImage: Constants.homeIconString)
                }
            Text(Constants.upcommingString)
                .tabItem {
                    Label(Constants.upcommingString, systemImage: Constants.upcommingIconString)
                }
            Text(Constants.searchingString)
                .tabItem {
                    Label(Constants.searchingString, systemImage: Constants.searchingIconString)
                }
            Text(Constants.downloadString)
                .tabItem {
                    Label(Constants.downloadString, systemImage: Constants.downloadIconString)
                }
        }
    }
}

#Preview {
    ContentView()
}
