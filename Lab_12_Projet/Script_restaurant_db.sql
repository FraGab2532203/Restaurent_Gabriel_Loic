-- =========================
-- BASE DE DONNÉES
-- =========================

CREATE DATABASE IF NOT EXISTS restaurant;
USE restaurant;

-- =========================
-- TABLE : UNITÉS
-- =========================
CREATE TABLE unites (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nom VARCHAR(50) NOT NULL
);

-- =========================
-- TABLE : CATÉGORIES
-- =========================
CREATE TABLE categories (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nom VARCHAR(100) NOT NULL
);

-- =========================
-- TABLE : INGRÉDIENTS
-- =========================
CREATE TABLE ingredients (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nom VARCHAR(100) NOT NULL,
    unite_id INT NOT NULL,
    prix    DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (unite_id) REFERENCES unites(id)
);

-- =========================
-- TABLE : INVENTAIRE
-- =========================
CREATE TABLE inventaire (
    ingredient_id INT PRIMARY KEY,
    quantite_stock DECIMAL(10,2) NOT NULL DEFAULT 0,
    seuil_alerte DECIMAL(10,2) NOT NULL DEFAULT 0,
    FOREIGN KEY (ingredient_id) REFERENCES ingredients(id)
        ON DELETE CASCADE
);

-- =========================
-- TABLE : MOUVEMENTS DE STOCK
-- =========================
CREATE TABLE mouvements_stock (
    id INT AUTO_INCREMENT PRIMARY KEY,
    ingredient_id INT NOT NULL,
    type ENUM('ENTREE', 'SORTIE') NOT NULL,
    quantite DECIMAL(10,2) NOT NULL,
    date_mouvement DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (ingredient_id) REFERENCES ingredients(id)
);

-- =========================
-- TABLE : PLATS
-- =========================
CREATE TABLE plats (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nom VARCHAR(150) NOT NULL,
    description TEXT,
    prix DECIMAL(10,2) NOT NULL,
    categorie_id INT,
    FOREIGN KEY (categorie_id) REFERENCES categories(id)
        ON DELETE SET NULL
);

-- =========================
-- TABLE : PLAT_INGRÉDIENTS
-- =========================
CREATE TABLE plat_ingredients (
    plat_id         INT             NOT NULL,
    ingredient_id   INT             NOT NULL,
    quantite        DECIMAL(10,2)   NOT NULL,
    PRIMARY KEY (plat_id, ingredient_id),
    FOREIGN KEY (plat_id) REFERENCES plats(id)
        ON DELETE CASCADE,
    FOREIGN KEY (ingredient_id) REFERENCES ingredients(id)
        ON DELETE CASCADE
);

-- =========================
-- DONNÉES
-- =========================

-- UNITÉS
INSERT INTO unites (nom) VALUES
('g'), ('ml'), ('unité');

-- CATÉGORIES
INSERT INTO categories (nom) VALUES
('Entrée'),
('Plat principal'),
('Dessert'),
('Boisson');

-- INGRÉDIENTS
INSERT INTO ingredients (nom, unite_id, prix) VALUES
('Poulet', 1, 2.99),
('Boeuf', 1, 3.99),
('Riz', 1, 1.39),
('Pâtes', 1, 0.39),
('Tomate', 1, .50),
('Lait', 2, 4.25),
('Fromage', 1, 4.50),
('Sucre', 1, 1.00),
('Farine', 1, 2.25),
('Oeuf', 3, 3.30),
('Beurre', 1, 2.50),
('Salade', 1, 1.25),
('Pain', 3, 2.95),
('Eau', 2, 0.25),
('Café', 1, 0.67);

-- INVENTAIRE INITIAL
INSERT INTO inventaire (ingredient_id, quantite_stock) VALUES
(1, 5000),
(2, 4000),
(3, 3000),
(4, 3000),
(5, 2000),
(6, 5000),
(7, 1500),
(8, 2000),
(9, 2500),
(10, 200),
(11, 1000),
(12, 800),
(13, 100),
(14, 10000),
(15, 500);

-- PLATS
INSERT INTO plats (nom, description, prix, categorie_id) VALUES
('Poulet au riz', 'Poulet grillé avec riz', 14.99, 2),
('Spaghetti bolognaise', 'Pâtes avec sauce au boeuf', 13.50, 2),
('Salade composée', 'Salade fraîche avec légumes', 9.00, 1),
('Omelette', 'Oeufs battus cuits', 7.50, 2),
('Gâteau', 'Dessert sucré maison', 6.50, 3),
('Croque-monsieur', 'Sandwich chaud fromage/jambon', 8.50, 2),
('Café', 'Boisson chaude', 2.50, 4);

-- PLAT_INGRÉDIENTS
INSERT INTO plat_ingredients VALUES
(1, 1, 200), (1, 3, 150), (1, 5, 50),
(2, 2, 150), (2, 4, 200), (2, 5, 100),
(3, 12, 100), (3, 5, 50),
(4, 10, 3), (4, 11, 20),
(5, 9, 150), (5, 8, 100), (5, 10, 2),
(6, 13, 2), (6, 7, 50),
(7, 15, 10), (7, 14, 200);

SELECT ingredients.id AS id, ingredients.nom AS nom, unites.nom AS nom_unite, inventaire.quantite_stock, ingredients.prix 
            FROM ingredients left JOIN inventaire ON inventaire.ingredient_id = ingredients.id 
            left JOIN unites ON unites.id = ingredients.unite_id