//
//  TitleDetailView.swift
//  MovieFlix
//
//  Created by LihinduPerera on 2026-09-30.
//

import SwiftUI

struct TitleDetailView: View {
    let title : Title
    var body: some View {
        GeometryReader { geometry in
            ScrollView {
                LazyVStack(alignment: .leading) {
                    YoutubePlayer(videoId: "8TZMtslA3UY")
                        .aspectRatio(1.3, contentMode: .fit)
                    
                    Text((title.name ?? title.title) ?? "")
                        .bold()
                        .font(.title2)
                        .padding(5)
                    
                    Text(title.overview ?? "")
                        .padding(5)
                }
            }
        }
    }
}

#Preview {
    TitleDetailView(title: Title.previewTitles[0])
}
