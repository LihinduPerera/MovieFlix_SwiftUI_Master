//
//  SearchView.swift
//  MovieFlix
//
//  Created by Lihindu Perera on 2026-10-03.
//

import SwiftUI

struct SearchView: View {
    @State private var searchByMovies = true
    @State private var searchText = ""
    @State private var searchViewModel = SearchViewModel()
    @State private var navigationPath = NavigationPath()
    
    var body: some View {
        NavigationStack(path: $navigationPath){
            ScrollView {
                VStack(alignment: .leading, spacing: 16) {
                    if let error = searchViewModel.errorMessage {
                        Text(error)
                            .errorMessage()
                    }

                    LazyVGrid(columns: Array(repeating: GridItem(.fixed(120), spacing: 12), count: 3), spacing: 12) {
                        ForEach(searchViewModel.searchTitles) { title in
                            AsyncImage(url: URL(string: title.posterPath ?? "")) { image in
                                image
                                    .resizable()
                                    .scaledToFill()
                            } placeholder: {
                                ProgressView()
                            }
                            .frame(width: 120, height: 200)
                            .clipShape(.rect(cornerRadius: 10))
                            .onTapGesture {
                                navigationPath.append(title)
                            }
                        }
                    }
                }
                .scrollTargetLayout()
                .padding(.horizontal, 12)
                .padding(.top, 8)
            }
            .navigationTitle(searchByMovies ? Constants.movieSearchString : Constants.tvSearchString)
            .toolbar {
                ToolbarItem(placement: .topBarTrailing) {
                    Button {
                        searchByMovies.toggle()
                        
                        Task {
                            await searchViewModel.getSearchTitles(by: searchByMovies ? "movie" : "tv", for: searchText)
                        }
                        
                    } label: {
                        Image(systemName: searchByMovies ? Constants.movieIconString : Constants.tvIconString)
                    }
                }
            }
            .searchable(text: $searchText, prompt: searchByMovies ? Constants.moviePlaceHolderString : Constants.tvPlaceHolderString)
            .task(id: searchText) {
                try? await Task.sleep(for: .milliseconds(500))
                
                if Task.isCancelled {
                    return
                }
                
                await searchViewModel.getSearchTitles(by: searchByMovies ? "movie" : "tv", for: searchText)
            }
            .navigationDestination(for: Title.self) { title in
                TitleDetailView(title: title)
            }
        }
    }
}

#Preview {
    SearchView()
}
