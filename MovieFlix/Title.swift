//
//  Title.swift
//  MovieFlix
//
//  Created by LihinduPerera on 2026-09-29.
//

import Foundation

struct APIObject: Decodable {
    var results: [Title] = []
}

struct Title: Decodable, Identifiable{
    var id : Int?
    var title: String?
    var name: String?
    var overview: String?
    var posterPath: String?
}
