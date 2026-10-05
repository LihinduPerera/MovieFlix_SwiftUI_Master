//
//  DownloadView.swift
//  MovieFlix
//
//  Created by Lihindu Perera on 2026-10-05.
//

import SwiftUI
import SwiftData

struct DownloadView: View {
    @Query var savedTitles: [Title]
    
    var body: some View {
        NavigationStack {
            if savedTitles.isEmpty {
                Text("No Downloads")
                    .padding()
                    .font(.title3)
                    .bold()
            } else {
                VerticalListView(titles: savedTitles)
            }
        }
    }
}

#Preview {
    DownloadView()
}
