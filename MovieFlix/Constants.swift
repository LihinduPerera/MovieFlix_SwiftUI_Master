//
//  Constants.swift
//  MovieFlix
//
//  Created by LihinduPerera on 2026-09-28.
//

import Foundation
import SwiftUI

struct Constants {
    static let homeString = "Home"
    static let upcommingString = "Upcomming"
    static let searchingString = "Search"
    static let downloadString = "Download"
    static let playString = "Play"
    static let trendingMovieString = "Trending Movies"
    
    static let homeIconString = "house"
    static let upcommingIconString = "play.circle"
    static let searchingIconString = "magnifyingglass"
    static let downloadIconString = "arrow.down.to.line"

    static let testTitleURL = "https://image.tmdb.org/t/p/w500/nnl6OWkyPpuMm595hmAxNW3rZFn.jpg"
    static let testTitleURL2 = "https://image.tmdb.org/t/p/w500/d5iIlFn5s0ImszYzBPb8JPIfbXD.jpg"
    static let testTitleURL3 = "https://image.tmdb.org/t/p/w500/qJ2tW6WMUDux911r6m7haRef0WH.jpg"
}

extension Text {
    func ghostButton() -> some View {
        self
            .frame(width: /*@START_MENU_TOKEN@*/100/*@END_MENU_TOKEN@*/, height: 50)
            .foregroundStyle(.buttonText)
            .bold()
            .background {
                RoundedRectangle(cornerRadius: 20, style: /*@START_MENU_TOKEN@*/.continuous/*@END_MENU_TOKEN@*/)
                    .stroke(.buttonBorder,lineWidth: 5)
        }
    }
}
