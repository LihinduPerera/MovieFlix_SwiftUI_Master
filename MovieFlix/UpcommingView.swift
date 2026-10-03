//
//  UpcommingView.swift
//  MovieFlix
//
//  Created by Lihindu Perera on 2026-10-03.
//

import SwiftUI

struct UpcommingView: View {
    var body: some View {
        VerticalListView(titles: Title.previewTitles)
    }
}

#Preview {
    UpcommingView()
}
