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
            Text("Home")
                .tabItem {
                    Label("Home", systemImage: "house")
                }
            Text("Upcomming")
                .tabItem {
                    Label("Upcomming", systemImage: "play.circle")
                }
            Text("Search")
                .tabItem {
                    Label("Search", systemImage: "magnifyingglass")
                }
            Text("Download")
                .tabItem {
                    Label("Download", systemImage: "arrow.down.to.line")
                }
        }
    }
}

#Preview {
    ContentView()
}
