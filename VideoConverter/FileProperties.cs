﻿using System;
using System.IO;

namespace VideoConverter
{
    public static class FileProperties
    {
        public static string GetProperty(string filePath, PropertiesEnum property)
        {
            var folder = new Shell32.Shell().NameSpace(Path.GetDirectoryName(filePath));
            var item = folder.ParseName(Path.GetFileName(filePath));
            var fixed_Data = RemoveMiscChar(folder.GetDetailsOf(item, (int)property));
            return fixed_Data;
        }

        public static DateTime GetDateTimeProperty(string filePath, PropertiesEnum property)
        {
            var folder = new Shell32.Shell().NameSpace(Path.GetDirectoryName(filePath));
            var item = folder.ParseName(Path.GetFileName(filePath));
            var fixed_Data = RemoveMiscChar(folder.GetDetailsOf(item, (int)property));

            if (!string.IsNullOrWhiteSpace(fixed_Data))
            {
                return DateTime.Parse(fixed_Data);
            }
            else
            {
                return ErrorTime;
            }
        }

        public static TimeSpan GetTimeSpanProperty(string filePath, PropertiesEnum property)
        {
            var folder = new Shell32.Shell().NameSpace(Path.GetDirectoryName(filePath));
            var item = folder.ParseName(Path.GetFileName(filePath));
            var fixed_Data = RemoveMiscChar(folder.GetDetailsOf(item, (int)property));

            if (!string.IsNullOrWhiteSpace(fixed_Data))
            {
                return TimeSpan.Parse(fixed_Data);
            }
            else
            {
                return new TimeSpan();
            }
        }


        public static DateTime ErrorTime = new DateTime();

        private static string RemoveMiscChar(string date)
        {
            char[] chars = date.ToCharArray();
            string newString = "";
            foreach (char chr in chars)
            {
                if (chr != 8207 && chr != 8206)
                {
                    newString += chr;
                }
            }
            return newString;
        }


        public enum PropertiesEnum
        {
            Name = 0,
            Size = 1,
            Itemtype = 2,
            Datemodified = 3,
            Datecreated = 4,
            Dateaccessed = 5,
            Attributes = 6,
            Offlinestatus = 7,
            Availability = 8,
            Perceivedtype = 9,
            Owner = 10,
            Kind = 11,
            Datetaken = 12,
            Contributingartists = 13,
            Album = 14,
            Year = 15,
            Genre = 16,
            Conductors = 17,
            Tags = 18,
            Rating = 19,
            Authors = 20,
            Title = 21,
            Subject = 22,
            Categories = 23,
            Comments = 24,
            Copyright = 25,
            misc = 26,
            Length = 27,
            Bitrate = 28,
            Protected = 29,
            Cameramodel = 30,
            Dimensions = 31,
            Cameramaker = 32,
            Company = 33,
            Filedescription = 34,
            Masterskeywords = 35,
            Masterskeywords1 = 36,

            Programname = 42,
            Duration = 43,
            Isonline = 44,
            Isrecurring = 45,
            Location = 46,
            Optionalattendeeaddresses = 47,
            Optionalattendees = 48,
            Organiseraddress = 49,
            Organisername = 50,
            Remindertime = 51,
            Requiredattendeeaddresses = 52,
            Requiredattendees = 53,
            Resources = 54,
            Meetingstatus = 55,
            Freebusystatus = 56,
            Totalsize = 57,
            Accountname = 58,

            Taskstatus = 60,
            Computer = 61,
            Anniversary = 62,
            Assistantsname = 63,
            Assistantsphone = 64,
            Birthday = 65,
            Businessaddress = 66,
            Businesscity = 67,
            Businesscountryregion = 68,
            BusinessPObox = 69,
            Businesspostcode = 70,
            Businesscountyregion = 71,
            Businessstreet = 72,
            Businessfax = 73,
            Businesshomepage = 74,
            Businessphone = 75,
            Callbacknumber = 76,
            Carphone = 77,
            Children = 78,
            Companymainphone = 79,
            Department = 80,
            Emailaddress = 81,
            Email2 = 82,
            Email3 = 83,
            Emaillist = 84,
            Emaildisplayname = 85,
            Fileas = 86,
            Firstname = 87,
            Fullname = 88,
            Gender = 89,
            Givenname = 90,
            Hobbies = 91,
            Homeaddress = 92,
            Homecity = 93,
            Homecountryregion = 94,
            HomePObox = 95,
            Homepostcode = 96,
            Homecountyregion = 97,
            Homestreet = 98,
            Homefax = 99,
            Homephone = 100,
            IMaddresses = 101,
            Initials = 102,
            Jobtitle = 103,
            Label = 104,
            Surname = 105,
            Postaladdress = 106,
            Middlename = 107,
            Mobilephone = 108,
            Nickname = 109,
            Officelocation = 110,
            Otheraddress = 111,
            Othercity = 112,
            Othercountryregion = 113,
            OtherPObox = 114,
            Otherpostcode = 115,
            OthercountyRegion = 116,
            Otherstreet = 117,
            Pager = 118,
            Personaltitle = 119,
            City = 120,
            CountryRegion = 121,
            PObox = 122,
            Postcode = 123,
            CountyRegion = 124,
            Street = 125,
            Primaryemail = 126,
            Primaryphone = 127,
            Profession = 128,
            SpousePartner = 129,
            Suffix = 130,
            TTYTTDphone = 131,
            Telex = 132,
            Webpage = 133,
            Contentstatus = 134,
            Contenttype = 135,
            Dateacquired = 136,
            Datearchived = 137,
            Datecompleted = 138,
            Devicecategory = 139,
            Connected = 140,
            Discoverymethod = 141,
            Friendlyname = 142,
            Localcomputer = 143,
            Manufacturer = 144,
            Model = 145,
            Paired = 146,
            Classification = 147,
            Status = 148,
            Status1 = 149,
            ClientID = 150,
            Contributors = 151,
            Contentcreated = 152,
            Lastprinted = 153,
            Datelastsaved = 154,
            Division = 155,
            DocumentID = 156,
            Pages = 157,
            Slides = 158,
            Totaleditingtime = 159,
            Wordcount = 160,
            Duedate = 161,
            Enddate = 162,
            Filecount = 163,
            Fileextension = 164,
            Filename = 165,
            Fileversion = 166,
            Flagcolour = 167,
            Flagstatus = 168,
            Spacefree = 169,

            Group = 172,
            Sharingtype = 173,
            Bitdepth = 174,
            Horizontalresolution = 175,
            Width = 176,
            Verticalresolution = 177,
            Height = 178,
            Importance = 179,
            Isattachment = 180,
            Isdeleted = 181,
            Encryptionstatus = 182,
            Hasflag = 183,
            Iscompleted = 184,
            Incomplete = 185,
            Readstatus = 186,
            Shared = 187,
            Creators = 188,
            Date = 189,
            Foldername = 190,
            Folderpath = 191,
            Folder = 192,
            Participants = 193,
            Path = 194,
            Bylocation = 195,
            Type = 196,
            Contactnames = 197,
            Entrytype = 198,
            Language = 199,
            Datevisited = 200,
            Description = 201,
            Linkstatus = 202,
            Linktarget = 203,
            URL = 204,

            Mediacreated = 208,
            Datereleased = 209,
            Encodedby = 210,
            Episodenumber = 211,
            Producers = 212,
            Publisher = 213,
            Seasonnumber = 214,
            Subtitle = 215,
            UserwebURL = 216,
            Writers = 217,

            Attachments = 219,
            Bccaddresses = 220,
            Bcc = 221,
            Ccaddresses = 222,
            Cc = 223,
            ConversationID = 224,
            Datereceived = 225,
            Datesent = 226,
            Fromaddresses = 227,
            From = 228,
            Hasattachments = 229,
            Senderaddress = 230,
            Sendername = 231,
            Store = 232,
            Toaddresses = 233,
            Todotitle = 234,
            To = 235,
            Mileage = 236,
            Albumartist = 237,
            Sortalbumartist = 238,
            AlbumID = 239,
            Sortalbum = 240,
            Sortcontributingartists = 241,
            BeatsPerMinute = 242,
            Composers = 243,
            Sortcomposer = 244,
            Disc = 245,
            Initialkey = 246,
            Partofacompilation = 247,
            Mood = 248,
            Partofset = 249,
            Fullstop = 250,
            Colour = 251,
            Parentalrating = 252,
            Parentalratingreason = 253,
            Spaceused = 254,
            EXIFversion = 255,
            Event = 256,
            Exposurebias = 257,
            Exposureprogram = 258,
            Exposuretime = 259,
            Fstop = 260,
            Flashmode = 261,
            Focallength = 262,
            focallength35mm = 263,
            ISOspeed = 264,
            Lensmaker = 265,
            Lensmodel = 266,
            Lightsource = 267,
            Maxaperture = 268,
            Meteringmode = 269,
            Orientation = 270,
            People = 271,
            Programmode = 272,
            Saturation = 273,
            Subjectdistance = 274,
            Whitebalance = 275,
            Priority = 276,
            Project = 277,
            Channelnumber = 278,
            Episodename = 279,
            Closedcaptioning = 280,
            Rerun = 281,
            SAP = 282,
            Broadcastdate = 283,
            Programdescription = 284,
            Recordingtime = 285,
            Stationcallsign = 286,
            Stationname = 287,
            Summary = 288,
            Snippets = 289,
            Autosummary = 290,
            Relevance = 291,
            Fileownership = 292,
            Sensitivity = 293,
            Sharedwith = 294,
            Sharingstatus = 295,

            Productname = 297,
            Productversion = 298,
            Supportlink = 299,
            Source = 300,
            Startdate = 301,
            Sharing = 302,
            Availabilitystatus = 303,
            Status2 = 304,
            Billinginformation = 305,
            Complete = 306,
            Taskowner = 307,
            Sorttitle = 308,
            Totalfilesize = 309,
            Legaltrademarks = 310,
            Videocompression = 311,
            Directors = 312,
            Datarate = 313,
            Frameheight = 314,
            Framerate = 315,
            Framewidth = 316,
            Spherical = 317,
            Stereo = 318,
            Videoorientation = 319,
            Totalbitrate = 320

        }
    }


}
