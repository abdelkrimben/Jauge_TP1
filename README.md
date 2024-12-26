README

Introduction

Ce projet, Jauge_TP1, implémente une jauge graphique en C# utilisant Windows Forms. L'application fournit une jauge horizontale interactive permettant de visualiser une valeur comprise entre un minimum et un maximum configurables.

Fonctionnalités

Jauge graphique personnalisée :

Affichage d'une jauge horizontale avec des valeurs dynamiques.

Indicateurs visuels pour les graduations principales et intermédiaires.

Dégradés pour un rendu esthétique.

Personnalisation des valeurs :

Réglage des valeurs minimale et maximale de la jauge.

Mise à jour interactive de la valeur actuelle via une interface utilisateur.

Barre de progression dynamique :

Représentation proportionnelle de la valeur actuelle.

Dégradé coloré (orange-rouge).

Structure des fichiers

DialGauge.cs :
Composant graphique principal pour afficher la jauge. Ce fichier définit la logique et le rendu de la jauge.

Form1.cs :
Interface utilisateur principale permettant l'interaction avec la jauge.

Program.cs :
Point d'entrée de l'application.

GaugeControl.cs :
Contrôle utilisateur supplémentaire permettant une implémentation alternative de la jauge.

Configuration du projet

Prérequis

Visual Studio 2019 ou version ultérieure

Framework .NET version 4.7.2 ou ultérieure

Installation

Clonez ou téléchargez ce dépôt sur votre machine locale.

Ouvrez le fichier solution dans Visual Studio.

Assurez-vous que tous les packages nécessaires sont correctement restaurés.

Exécution

Compilez et exécutez le projet à l'aide de F5 ou du bouton de démarrage dans Visual Studio.

Dans l'application :

Saisissez une valeur dans la zone de texte.

Cliquez sur le bouton "Changer valeur" pour mettre à jour la jauge.
