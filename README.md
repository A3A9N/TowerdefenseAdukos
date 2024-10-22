# DefenseTheTown
Dit is een template wat door jullie te gebruiken is voor het juist inleveren van alle producten voor de Towerdefense beroepsopdracht. **Verwijder uiteindelijk de template teksten!**

Begin met een korte omschrijving van je towerdefense game en hoe deze werkt. Plaats ook een paar screenshots.

![not really my game](https://cdn.akamai.steamstatic.com/steam/apps/246420/ss_aaaf33cdb9106bd0801a36049516d95c6f2352b0.600x338.jpg?t=1686321490)

![also not](https://cdn.akamai.steamstatic.com/steam/apps/960090/ss_900d7c00d45ff2a258d4c8d59ee47f7f04854c37.600x338.jpg?t=1686097340)


## Product 1: "DRY SRP Scripts op GitHub"

EnemySpawner.cs
Waarom het voldoet aan DRY: Ik gebruik een array enemyPrefabs om verschillende vijanden te spawnen, waardoor ik geen herhalende code nodig heb voor elk type vijand. Dit maakt het eenvoudig om nieuwe vijanden toe te voegen door ze alleen aan de array toe te voegen.

Waarom het voldoet aan het Single Responsibility Principle: Dit script is uitsluitend verantwoordelijk voor het spawnen van vijanden en het beheren van waves. Hierdoor is de functionaliteit duidelijk afgebakend, wat het onderhoud en de uitbreiding van de code vergemakkelijkt.
[link naar script](https://github.com/A3A9N/TowerdefenseAdukos/blob/main/Assets/Code/Scripts/Enemy/EnemySpawner.cs)"*

## Product 2: "Projectmappen op GitHub"

Dit is de [ROOT](https://github.com/A3A9N/TowerdefenseAdukos/tree/main/Assets) folder van mijn unity project.

Zorg dat deze verwijst naar je Develop branch.

## Product 3: Build op Github

Je maakt in Unity een stabiele “build” van je game waarbij bugs en logs eerst zijn verwijderd. Deze buildfiles upload je in je repository onder releases.  Bij eventuele afwijkingen moeten deze worden gedocumenteerd in de release. (Bijv controller nodig of spelen via netwerk etc..) 

[Release](https://github.com/A3A9N/TowerdefenseAdukos/releases/tag/Releases)

## Product 4: Game met Sprites(animations) en Textures 

De build van je game bevat textures, sprites en sprite animations(bijv particles) die op de juiste manier zijn gebruikt en zorgen voor een goede afwerking van je game.  

Plaats in je readme een animated gif van je gameplay (+- 10 sec.) waarin de implementatie van je textures en sprites goed te zien is.

![Textures Sprites](readmeVisuals/texturesSprites.gif)

## Product 5: Issues met debug screenshots op GitHub 

Zodra je bugs tegenkomt maak je een issue aan op github. In de issue omschrijf je het probleem en je gaat proberen via breakpoints te achterhalen wat het probleem is. Je maakt screenshot(s) van het debuggen op het moment dat je via de debugger console ziet wat er mis is. Deze screenshots met daarbij uitleg over het probleem en de bijhorende oplossing post je in het bijhorende github issue. 
[Hier de link naar mijn issues](https://github.com/erwinhenraat/TowerDefenseTemplate/issues/)

## Product 6: Game design met onderbouwing 

Game Design Keuzes
Torens en Beweging:
Torens schieten op bewegende vijanden met een field of view van 90 graden, wat strategische plaatsing en rotatie vereist. Dit dwingt spelers om goed na te denken over hun verdediging.

Vernietigbare Vijanden:
De game heeft drie typen vijanden: snelle, kwetsbare vijanden en langzame, gepantserde vijanden. Spelers moeten balanceren tussen het plaatsen van veel goedkope torens en het effectief beheren van hun middelen, vooral tegen de gepantserde vijanden die alleen door specifieke torens kunnen worden vernietigd.

Wave Systeem:
Nieuwe vijanden verschijnen in waves, wat zorgt voor constante actie en aanpassing van de strategie van de speler. Dit verhoogt de uitdaging en het gevoel van progressie.

Health Systeem:
Spelers verliezen levens als vijanden hun doel bereiken, wat directe consequenties geeft voor hun acties en de urgentie verhoogt om effectief te verdedigen.

Resource Systeem:
Middelen worden verdiend door vijanden te verslaan en kunnen worden gebruikt om torens te kopen. Dit stimuleert strategische beslissingen over het gebruik van middelen.

Movement Prediction Systeem:
Torens voorspellen de beweging van vijanden om effectief te kunnen schieten. Dit voegt complexiteit toe en vereist zorgvuldige planning van spelers.

## Product 7: Class Diagram voor volledige codebase 

---
title: Tower Defense Game
---
classDiagram
    note "Classes in the Tower Defense Game"
    BuildManager <|-- Tower
    LevelManager <|-- Plot
    LevelManager <|-- EnemyMovement
    LevelManager <|-- Health
    LevelManager <|-- Bullet
    LevelManager <|-- Menu

    class BuildManager {
        +Tower[] towers
        +Tower GetSelectedBuild()
        +void SetSelectedBuild(int selectedBuild)
    }

    class Tower {
        +string name
        +int cost
        +GameObject prefab
    }

    class LevelManager {
        +Transform startPoint
        +Transform[] path
        +int currency
        +void IncreaseCurrency(int amount)
        +bool SpendCurrency(int amount)
    }

    class Plot {
        +SpriteRenderer sr
        +Color hoverColor
        +void OnMouseEnter()
        +void OnMouseExit()
        +void OnMouseDown()
    }

    class EnemyMovement {
        +float moveSpeed
        +void Initialize(EnemySpawner spawner)
        +void Start()
        +void Update()
        +void FixedUpdate()
    }

    class Health {
        +int hitPoints
        +int currencyWorth
        +void TakeDamage(int damage)
    }

    class Bullet {
        +Rigidbody2D rb
        +float bulletSpeed
        +int bulletDamage
        +void SetTarget(Transform target)
        +void FixedUpdate()
        +void OnCollisionEnter2D(Collision2D collision)
    }

    class Menu {
        +TextMeshProUGUI currencyUI
        +Animator anim
        +void ToggleMenu()
        +void OnGUI()
        +void SetSelected()
    }


## Product 8: Prototype test video
Je hebt een werkend prototype gemaakt om een idee te testen. Omschrijf if je readme wat het idee van de mechanics is geweest wat je wilde testen en laat een korte video van de gameplay test zien. 

[![example test video](https://ucarecdn.com/dbdc3ad0-f375-40ad-8987-9e6451b28b50/)](https://www.youtube.com/watch?v=CzzRML1swF0)

## Product 9: SCRUM planning inschatting 

TRELLO:

[Link naar de openbare trello](https://trello.com/b/wodkERN3/towerdefensea3)

## Product 10: Gitflow conventions

Je hebt voor je eigen project in je readme gitflow conventies opgesteld en je hier ook aantoonbaar aan gehouden. 

De gitflow conventions gaan uit van een extra branch Develop naast de "Master"/"Main". Op de main worden alleen stabiele releases gezet.

Verder worden features op een daarvoor bedoelde feature banch ontwikkeld. Ook kun je gebruik maken van een hotfix brancg vanaf develop.

Leg hier uit welke branches jij gaat gebruiken en wat voor namen je hier aan gaat meegeven. Hoe vaak ga je comitten en wat voor commit messages wil je geven?

Meer info over het gebruiken van gitflow [hier](https://www.atlassian.com/git/tutorials/comparing-workflows/gitflow-workflow)

