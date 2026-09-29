//
//  APIConfig.swift
//  MovieFlix
//
//  Created by LihinduPerera on 2026-09-29.
//

import Foundation

struct APIConfig: Decodable {
    let tmdbBaseURL: String
    let tmdbAPIKey: String
    
    static let shared: APIConfig = {
        guard let url = Bundle.main.url(forResource: "APIConfig", withExtension: "json") else {
            fatalError("APIConfig.json is missing or invalid!!!")
        }
        
        do {
            let data = try Data(contentsOf: url)
            return try JSONDecoder().decode(APIConfig.self, from: data)
        } catch {
            fatalError("Failed to lead or decode APIConfig.json: \(error)")
        }
    }()
}
