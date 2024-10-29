CREATE DATABASE EnglishLearningDb;
USE EnglishLearningDb;
-- Bảng Users
CREATE TABLE Users (
    user_id INT PRIMARY KEY IDENTITY(1,1),
    email VARCHAR(255) NOT NULL UNIQUE,
    password VARCHAR(255) NOT NULL,
    subscription_plan VARCHAR(50) CHECK (subscription_plan IN ('Free', 'Premium', 'Enterprise')),
    subscription_start_date DATETIME,
    subscription_end_date DATETIME,
    role VARCHAR(50) CHECK (role IN ('Student', 'Admin'))
);

-- Bảng Payments
CREATE TABLE Payments (
    payment_id INT PRIMARY KEY IDENTITY(1,1),
    user_id INT NOT NULL,
    amount DECIMAL(10, 2),
    payment_date DATETIME,
    payment_method VARCHAR(255)
);

-- Bảng Subscriptions
CREATE TABLE Subscriptions (
    subscription_id INT PRIMARY KEY IDENTITY(1,1),
    user_id INT NOT NULL,
    [plan] VARCHAR(50) CHECK ([plan] IN ('Monthly', 'Yearly')),
    start_date DATETIME,
    end_date DATETIME
);

-- Bảng Courses
CREATE TABLE Courses (
    course_id INT PRIMARY KEY IDENTITY(1,1),
    course_name VARCHAR(255),
    description TEXT
);

-- Bảng Topics
CREATE TABLE Topics (
    topic_id INT PRIMARY KEY IDENTITY(1,1),
    topic_name VARCHAR(255),
    course_id INT,
    description TEXT,
    [order] INT
);

-- Bảng Vocabularies
CREATE TABLE Vocabularies (
    vocab_id INT PRIMARY KEY IDENTITY(1,1),
    word VARCHAR(255),
    meaning TEXT,
    example_sentence TEXT,
    topic_id INT,
    pronunciation TEXT
);

-- Bảng User_Progresses
CREATE TABLE User_Progresses (
    progress_id INT PRIMARY KEY IDENTITY(1,1),
    user_id INT NOT NULL,
    vocab_id INT NOT NULL,
    review_interval INT,
    last_reviewed DATETIME,
    next_review DATETIME
);

-- Thêm từng ràng buộc khoá ngoại riêng lẻ
ALTER TABLE Payments
ADD FOREIGN KEY (user_id) REFERENCES Users(user_id);

ALTER TABLE Subscriptions
ADD FOREIGN KEY (user_id) REFERENCES Users(user_id);

ALTER TABLE Topics
ADD FOREIGN KEY (course_id) REFERENCES Courses(course_id);

ALTER TABLE Vocabularies
ADD FOREIGN KEY (topic_id) REFERENCES Topics(topic_id);

ALTER TABLE User_Progresses
ADD FOREIGN KEY (user_id) REFERENCES Users(user_id);

ALTER TABLE User_Progresses
ADD FOREIGN KEY (vocab_id) REFERENCES Vocabularies(vocab_id);
