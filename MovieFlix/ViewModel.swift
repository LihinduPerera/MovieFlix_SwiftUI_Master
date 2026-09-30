//
//  ViewModel.swift
//  MovieFlix
//
//  Created by LihinduPerera on 2026-09-29.
//

import Foundation

@Observable
class ViewModel {
    enum FetchStatus {
        case notStarted
        case fetching
        case success
        case failed(underlyingError: Error)
    }
    private(set) var homeStatus: FetchStatus = .notStarted
    private let dataFetcher = DataFetcher()
    var trendingMovies: [Title] = []
    var trendingTV: [Title] = []
    var topRatedMovies: [Title] = []
    var topRatedTV: [Title] = []
    
    func getTitles() async {
        homeStatus = .fetching
        
        do {
            trendingMovies = try await dataFetcher.fetchTitles(for: "movie", by: "trending")
            trendingTV = try await dataFetcher.fetchTitles(for: "tv", by: "trending")
            topRatedMovies = try await dataFetcher.fetchTitles(for: "movie", by: "top_rated")
            topRatedTV = try await dataFetcher.fetchTitles(for: "tv", by: "top_rated")
            homeStatus = .success
        } catch {
            print(error)
            homeStatus = .failed(underlyingError: error)
        }
    }
}
