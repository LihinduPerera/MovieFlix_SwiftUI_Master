//
//  UpcommingView.swift
//  MovieFlix
//
//  Created by Lihindu Perera on 2026-10-03.
//

import SwiftUI

struct UpcommingView: View {
    let viewModel = ViewModel()
    
    var body: some View {
        GeometryReader {geo in
            switch viewModel.upComingStatus {
            case .notStarted:
                EmptyView()
            case .fetching:
                ProgressView()
                    .frame(width: geo.size.width, height: geo.size.height)
            case .success:
                VerticalListView(titles: viewModel.upcomingMovies)
            case .failed(let underlyingError):
                Text(underlyingError.localizedDescription)
            }
        }
        .task {
            await viewModel.getUpcomingMovies()
        }
    }
}

#Preview {
    UpcommingView()
}
