module Domain

open System

type Name = Name of string

type BirthDate = BirthDate of DateTime

type Link = Link of string

type Title = Title of string

type PublicAuthor =
    {
        Name : Name
        BirthDate : BirthDate
        Links : Link seq
    }

type PublicBook = 
    {
        Title : Title
        Authors : PublicAuthor seq 
    }
