//
//  YoutubePlayer.swift
//  MovieFlix
//
//  Created by Lihindu Perera on 2026-10-03.
//

import SwiftUI
import WebKit

struct YoutubePlayer: UIViewRepresentable {
    let videoId: String
    let youtubeBaseURL = APIConfig.shared?.youtubeBaseURL

    func makeUIView(context: Context) -> WKWebView {
        let configuration = WKWebViewConfiguration()
        let webView = WKWebView(frame: .zero, configuration: configuration)

        return webView
    }

    func updateUIView(_ webView: WKWebView, context: Context) {
        guard let baseURLString = youtubeBaseURL,
              let baseURL = URL(string: baseURLString) else {
            return
        }

        let videoURL = baseURL.appending(path: videoId)

        var request = URLRequest(url: videoURL)

        // Required by YouTube for embedded playback
        let bundleId = Bundle.main.bundleIdentifier ?? "com.LithiumStudios.MovieFlix"
        request.setValue(
            "https://\(bundleId)",
            forHTTPHeaderField: "Referer"
        )

        webView.load(request)

        print("YouTube URL:", videoURL)
        print("Referer:", "https://\(bundleId)")
    }
}
