using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Graubakken_Filmsjappe.Models.DBData
{
    public class FilmData
    {
        Film Film01 = new Film
        {
            Navn = "3 Dev Adam",
            Kontinent = "USA",
            Sjanger1 = "Action",
            Studio = "Renkli Studios",
            Produksjonsår = 1945,
            Bilde = "Content/images/posters/3devadam.jpg",
            Visninger = 12341,
            Beskrivelse = "Kaptein Amerika blir sendt til Tyrkia for å stoppe en krimbølge",
            ReleaseDate = DateTime.Now.ToString()
        };

        Film Film02 = new Film
        {
            Navn = "310 To Yuma",
            Kontinent = "USA",
            Sjanger1 = "Action",
            Sjanger2 = "Western",
            Studio = "Duff Studios",
            Produksjonsår = 1938,
            Bilde = "Content/images/posters/310_to_Yuma.jpg",
            Visninger = 2541,
            Beskrivelse = "En beryktet fredløs må stilles for retten, og en gruppe frivillige må eskortere han til 310 toget mot Yuma",
            ReleaseDate = DateTime.Now.AddDays(-1).ToString()
        };

        Film Film03 = new Film
        {
            Navn = "-30-",
            Kontinent = "England",
            Sjanger1 = "Krim",
            Sjanger2 = "Drama",
            Studio = "BBC",
            Produksjonsår = 1954,
            Bilde = "Content/images/posters/30_poster.jpg",
            Visninger = 4566,
            Beskrivelse = "En film basert på virkelige hendelser som følger 2 redaktører for Los Angeles Herald i det aktive livet til en storbyavis",
            ReleaseDate = DateTime.Now.AddDays(-2).ToString()
        };

        Film Film04 = new Film
        {
            Navn = "16 Days in Afghanistan",
            Kontinent = "USA",
            Sjanger1 = "Dokumentar",
            Studio = "Indiedev Studios",
            Produksjonsår = 2003,
            Bilde = "Content/images/posters/16_days_poster.jpeg",
            Visninger = 225541,
            Beskrivelse = "Film og dokumentarskaperen Anwar Hajher reiser tilbake til hjelmandet Afghanistan etter 25 år for å gjennoppdage landet sitt",
            ReleaseDate = DateTime.Now.AddDays(-3).ToString()
        };

        Film Film05 = new Film
        {
            Navn = "100 Million BC",
            Kontinent = "USA",
            Sjanger1 = "Action",
            Sjanger2 = "Eventyr",
            Studio = "Made-up Studios",
            Produksjonsår = 1986,
            Bilde = "Content/images/posters/100_Million_BC.jpg",
            Visninger = 221453,
            Beskrivelse = "Etter et mislykket tidsreise eksperiment må et redningsteam finne overlevende som har blitt sendt tilbake til forhistoriske tider",
            ReleaseDate = DateTime.Now.AddDays(-4).ToString()
        };

        Film Film06 = new Film
        {
            Navn = "100 Days With Mr Arrogant",
            Kontinent = "Korea",
            Sjanger1 = "Romantikk",
            Sjanger2 = "Komedie",
            Studio = "Sappy Lovestories",
            Produksjonsår = 2004,
            Bilde = "Content/images/posters/100_Days_With_Mr_Arrogant_poster.jpg",
            Visninger = 1244,
            Beskrivelse = "I denne romantiske komedien fra 2004 blir Ha-Young kastet inn i et tjener-liv for den arrogante Shin i 100 dager.",
            ReleaseDate = DateTime.Now.AddDays(-5).ToString()
        };

        Film Film07 = new Film
        {
            Navn = "5 Weddings",
            Kontinent = "India",
            Sjanger1 = "Drama",
            Sjanger2 = "Romantikk",
            Studio = "Sappy Lovestories",
            Produksjonsår = 1998,
            Bilde = "Content/images/posters/5_Weddings_Poster.jpg",
            Visninger = 3325,
            Beskrivelse = "En amerikansk journalist reiser til India for å skrive en historie om Bollywood bryllup. Oppdraget hennes blir avbrutt av en politimann som er overbevist om at det ligger spionasje bak artikkelen",
            ReleaseDate = DateTime.Now.AddDays(-6).ToString()
        };

        Film Film08 = new Film
        {
            Navn = "633 Squadron",
            Kontinent = "USA",
            Sjanger1 = "Action",
            Sjanger2 = "Drama",
            Studio = "Renkli Studios",
            Produksjonsår = 1964,
            Bilde = "Content/images/posters/633_Squadron_1964_poster.jpg",
            Visninger = 251546,
            Beskrivelse = "En jagerpilot skvadron får i oppdrag å bombe en Tysk rakettbensinfabrikk i Norge under andre verdenskrig",
            ReleaseDate = DateTime.Now.AddDays(-7).ToString()
        };

        Film Film09 = new Film
        {
            Navn = "7 Hours To Go",
            Kontinent = "India",
            Sjanger1 = "Action",
            Sjanger2 = "Krim",
            Studio = "Weabo Studios",
            Produksjonsår = 2014,
            Bilde = "Content/images/posters/7_Hours_To_Go_-_Movie_Poster.jpg",
            Visninger = 12341,
            Beskrivelse = "En desperat mann kidnapper 7 mennesker, og gir politiet begrenset tid til å finne bevis mot mannen som drepte hans forlovede",
            ReleaseDate = DateTime.Now.AddDays(-8).ToString()
        };

        Film Film10 = new Film
        {
            Navn = "Aladdin",
            Kontinent = "USA",
            Sjanger1 = "Animasjon",
            Sjanger2 = "Familie",
            Studio = "Walt Disney",
            Produksjonsår = 1992,
            Bilde = "Content/images/posters/Aladdinposter.jpg",
            Visninger = 855423,
            Beskrivelse = "I denne klassiske animasjonsfilmen finner fattiggutten Aladdin en magisk lampe, men finner fort ut at onde krefter har andre planer for lampen",
            ReleaseDate = DateTime.Now.AddDays(-9).ToString()
        };

        Film Film11 = new Film
        {
            Navn = "Along Came Jones",
            Kontinent = "USA",
            Sjanger1 = "Romantikk",
            Sjanger2 = "Western",
            Studio = "PastaWrangler Studios",
            Produksjonsår = 1958,
            Bilde = "Content/images/posters/Along_Came_Jones.jpg",
            Visninger = 45633,
            Beskrivelse = "Melody Jones, en lovlydig Cowboy ankommer en liten landsby hvor innbyggerne tror han er en beryktet lovløs",
            ReleaseDate = DateTime.Now.AddDays(-10).ToString()
        };

        Film Film12 = new Film
        {
            Navn = "Atlantis The Lost Empire",
            Kontinent = "USA",
            Sjanger1 = "Animasjon",
            Sjanger2 = "Familie",
            Studio = "Walt Disney",
            Produksjonsår = 2001,
            Bilde = "Content/images/posters/Atlantis_The_Lost_Empire_poster.jpg",
            Visninger = 12234,
            Beskrivelse = "En ung eventyrer blir nøkkelen til å løse et gammel mysterium i jakten på Atlantis",
            ReleaseDate = DateTime.Now.AddDays(-11).ToString()
        };

        Film Film13 = new Film
        {
            Navn = "Born To The West",
            Kontinent = "USA",
            Sjanger1 = "Action",
            Sjanger2 = "Western",
            Studio = "PastaWrangler Studios",
            Produksjonsår = 1937,
            Bilde = "Content/images/posters/Born_to_the_West_FilmPoster.jpeg",
            Visninger = 12224,
            Beskrivelse = "Kan den skruppeløse gambleren Dare Rudd bevise at han er ansvarlig nok til å kapre hjertet til Judy, og også utmanøvrere den slu saloon eieren?",
            ReleaseDate = DateTime.Now.AddDays(-12).ToString()
        };

        Film Film14 = new Film
        {
            Navn = "Calamity Jane",
            Kontinent = "USA",
            Sjanger1 = "Musikal",
            Sjanger2 = "Western",
            Studio = "Randolf Studios",
            Produksjonsår = 1953,
            Bilde = "Content/images/posters/Calamity_Jane_poster.jpg",
            Visninger = 14552,
            Beskrivelse = "I ensomme Deadwood, Dakota faller skarpskytteren Calamity Jane for kavalerimannen hun må redde fra indianerne",
            ReleaseDate = DateTime.Now.AddDays(-13).ToString()
        };

        Film Film15 = new Film
        {
            Navn = "$ (Dollars)",
            Kontinent = "USA",
            Sjanger1 = "Komedie",
            Sjanger2 = "Action",
            Studio = "Swingstyle Studios",
            Produksjonsår = 1971,
            Bilde = "Content/images/posters/dollars.jpg",
            Visninger = 75543,
            Beskrivelse = "I Hamburg, Tyskland blir bankbokser brukt av kriminelle for å gjemme tyvegods. Bankmannen Joe Collins kommer opp med en plan for å prøve å stjele tilbake pengene",
            ReleaseDate = DateTime.Now.AddDays(-14).ToString()
        };

        Film Film16 = new Film
        {
            Navn = "Hunchback of Notre Dame",
            Kontinent = "USA",
            Sjanger1 = "Animasjon",
            Sjanger2 = "Familie",
            Studio = "Walt Disney",
            Produksjonsår = 1996,
            Bilde = "Content/images/posters/Hunchbackposter.jpg",
            Visninger = 19985,
            Beskrivelse = "Denne animerte filmen følger ringeren i Notre Damme som lengter etter å være blant andre mennesker",
            ReleaseDate = DateTime.Now.AddDays(-15).ToString()
        };

        Film Film17 = new Film
        {
            Navn = "Jesse James",
            Kontinent = "USA",
            Sjanger1 = "Western",
            Sjanger2 = "Action",
            Studio = "PastaWrangler Studios",
            Produksjonsår = 1939,
            Bilde = "Content/images/posters/jesse_james.jpg",
            Visninger = 69542,
            Beskrivelse = "Jesse James og broren Frank sverger hevn mot St. Louis Midland Railroad etter at en representant for firmaet drepte moren deres",
            ReleaseDate = DateTime.Now.AddDays(-16).ToString()
        };

        Film Film18 = new Film
        {
            Navn = "Star Trek II - The Wrath of Khan",
            Kontinent = "USA",
            Sjanger1 = "Action",
            Sjanger2 = "Science Fiction",
            Studio = "Paramount Studio",
            Produksjonsår = 1982,
            Bilde = "Content/images/posters/Star_Trek_II_The_Wrath_of_Khan.png",
            Visninger = 75441,
            Beskrivelse = "Med hjelp av besetningen på The Enterprise, må admiral James Kirk stoppe sin gamle fiende Khan Noonien Singh",
            ReleaseDate = DateTime.Now.AddDays(-17).ToString()
        };

        Film Film19 = new Film
        {
            Navn = "Star Trek V - The Final Frontier",
            Kontinent = "USA",
            Sjanger1 = "Action",
            Sjanger2 = "Science Fiction",
            Studio = "Paramount Studio",
            Produksjonsår = 1989,
            Bilde = "Content/images/posters/Star_Trek_V_The_Final_Frontier.png",
            Visninger = 22354,
            Beskrivelse = "Kaptein Kirk og hans besetning må kjempe mot Spock's halvbror som kaprer The Enterprise i søken etter en Gud ved galaksens midtpunkt",
            ReleaseDate = DateTime.Now.AddDays(-18).ToString()
        };

        Film Film20 = new Film
        {
            Navn = "Star Wars - Episode II Attack of the Clones",
            Kontinent = "USA",
            Sjanger1 = "Action",
            Sjanger2 = "Science Fiction",
            Studio = "Lucasfilm LTD",
            Produksjonsår = 2002,
            Bilde = "Content/images/posters/Star_Wars_-_Episode_II_Attack_of_the_Clones.jpg",
            Visninger = 88542,
            Beskrivelse = "Ti år etter de opprinnelig møttes, deler Padmè og Anakin Skywalker en fordudt romanse, mens Obi-Wan Kenobi undersøker et attentattforsøk på en senator og oppdater en hemmelig klone armé",
            ReleaseDate = DateTime.Now.AddDays(-19).ToString()
        };

        Film Film21 = new Film
        {
            Navn = "Star Trek - Into Darkness",
            Kontinent = "USA",
            Sjanger1 = "Action",
            Sjanger2 = "Science Fiction",
            Studio = "Paramount Studio",
            Produksjonsår = 2013,
            Bilde = "Content/images/posters/StarTrekIntoDarkness_FinalUSPoster.jpg",
            Visninger = 55474,
            Beskrivelse = "Besetningen på The Enterprise returnerer hjem etter at en terroraksjon innenfor organisasjonen ødelegger det meste av Starfleet",
            ReleaseDate = DateTime.Now.AddDays(-20).ToString()
        };

        Film Film22 = new Film
        {
            Navn = "Star Wars Radio",
            Kontinent = "USA",
            Sjanger1 = "Action",
            Sjanger2 = "Science Fiction",
            Studio = "Lucasfilm LTD",
            Produksjonsår = 1987,
            Bilde = "Content/images/posters/SW-RadioPoster.jpg",
            Visninger = 7745,
            Beskrivelse = "En utvided radio dramatisering av den originale Star Wars trilogien",
            ReleaseDate = DateTime.Now.AddDays(-21).ToString()
        };

        Film Film23 = new Film
        {
            Navn = "Star Wars - Empire Strikes Back",
            Kontinent = "USA",
            Sjanger1 = "Action",
            Sjanger2 = "Science Fiction",
            Studio = "Lucasfilm LTD",
            Produksjonsår = 1980,
            Bilde = "Content/images/posters/SW_-_Empire_Strikes_Back.jpg",
            Visninger = 22548,
            Beskrivelse = "Luke Skywalker begynner sin trening som en Jedi med Yoda, mens vennene hans blir forfulgt av Darth Vader",
            ReleaseDate = DateTime.Now.AddDays(-22).ToString()
        };

        Film Film24 = new Film
        {
            Navn = "The Lion King",
            Kontinent = "USA",
            Sjanger1 = "Animasjon",
            Sjanger2 = "Familie",
            Studio = "Walt Disney",
            Produksjonsår = 1994,
            Bilde = "Content/images/posters/The_Lion_King_poster.jpg",
            Visninger = 88564,
            Beskrivelse = "I denne klassiske animasjonsperlen blir en ung løve lurt av sin slu onkel til å tro at han forårsaket farens død og flykter",
            ReleaseDate = DateTime.Now.AddDays(-23).ToString()
        };

        Film Film25 = new Film
        {
            Navn = "Two Family House",
            Kontinent = "USA",
            Sjanger1 = "Romantikk",
            Studio = "Sappy Lovestories",
            Produksjonsår = 1964,
            Bilde = "Content/images/posters/twofamilyposter.jpg",
            Visninger = 55648,
            Beskrivelse = "En kronisk drømmer finner ut at hans kone og venner holder han fast til hans middelmådige liv",
            ReleaseDate = DateTime.Now.AddDays(-24).ToString()
        };

        public List<Film> HentFilmListe()
        {
            List<Film> filmer = new List<Film>();
            filmer.Add(Film01);
            filmer.Add(Film02);
            filmer.Add(Film03);
            filmer.Add(Film04);
            filmer.Add(Film05);
            filmer.Add(Film06);
            filmer.Add(Film07);
            filmer.Add(Film08);
            filmer.Add(Film09);
            filmer.Add(Film10);
            filmer.Add(Film11);
            filmer.Add(Film12);
            filmer.Add(Film13);
            filmer.Add(Film14);
            filmer.Add(Film15);
            filmer.Add(Film16);
            filmer.Add(Film17);
            filmer.Add(Film18);
            filmer.Add(Film19);
            filmer.Add(Film20);
            filmer.Add(Film21);
            filmer.Add(Film22);
            filmer.Add(Film23);
            filmer.Add(Film24);
            filmer.Add(Film25);

            return filmer;
        }
    }
}