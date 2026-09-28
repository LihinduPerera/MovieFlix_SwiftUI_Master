//
//  HomeView.swift
//  MovieFlix
//
//  Created by LihinduPerera on 2026-09-28.
//

import SwiftUI

struct HomeView: View {
    var heroTestTitle = Constants.testTitleURL
    
    var body: some View {
        VStack {
            AsyncImage(url: URL(string: heroTestTitle)) { image in
                image
                    .resizable()
                    .scaledToFit()
            } placeholder: {
                ProgressView()
            }
            HStack {
                Button {
                    
                } label: {
                    Text(Constants.playString)
                        .frame(width: /*@START_MENU_TOKEN@*/100/*@END_MENU_TOKEN@*/, height: 50)
                        .foregroundStyle(.buttonText)
                        .bold()
                        .background {
                            RoundedRectangle(cornerRadius: 20, style: /*@START_MENU_TOKEN@*/.continuous/*@END_MENU_TOKEN@*/)
                                .stroke(.buttonBorder,lineWidth: 5)
                        }
                }
                Button {
                    
                } label: {
                    Text(Constants.downloadString)
                }
            }
        }
    }
}

#Preview {
    HomeView()
}
