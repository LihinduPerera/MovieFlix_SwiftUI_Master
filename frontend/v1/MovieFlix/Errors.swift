//
//  Errors.swift
//  MovieFlix
//
//  Created by LihinduPerera on 2026-09-29.
//

import Foundation

enum APIConfigError: Error, LocalizedError {
    case fileNotFound
    case dataLoadingError(underlyingError: Error)
    case decodingFailed(underlyingError: Error)
    
    var errorDescription: String? {
        switch self {
        case .fileNotFound:
            return "API Configoration file not found."
        case .dataLoadingError(underlyingError: let error):
            return "Failed to load data from API Configoration file: \(error.localizedDescription)."
        case .decodingFailed(underlyingError: let error):
            return "Failed to decode API Configoration: \(error.localizedDescription)."
        }
    }
}

enum NetworkError: Error, LocalizedError {
    case badURLResponse(underlyingError: Error)
    case missingConfig
    case urlBuildFailed

    var errorDescription: String? {
        switch self{
        case .badURLResponse(underlyingError: let error):
            return "Failed to prase URL Response: \(error.localizedDescription)."
        case .missingConfig:
            return "Missing API Configoration."
        case .urlBuildFailed:
            return "Failed to build URL."
        }
    }
}
