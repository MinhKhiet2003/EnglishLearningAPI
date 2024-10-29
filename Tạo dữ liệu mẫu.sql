INSERT INTO [EnglishLearningDb].[dbo].[Users] 
    ([email], [password], [subscription_plan], [subscription_start_date], [subscription_end_date], [role], [refresh_token], [refresh_token_expiry])
VALUES 
    ('user1@example.com', 'password123', 'Basic', '2023-01-01', '2024-01-01', 'User', 'token123', '2024-01-01 00:00:00'),
    ('user2@example.com', 'password456', 'Premium', '2023-05-15', '2024-05-15', 'User', 'token456', '2024-05-15 00:00:00'),
    ('admin@example.com', 'adminpass', 'Admin', '2023-10-01', '2024-10-01', 'Admin', 'token789', '2024-10-01 00:00:00'),
    ('user3@example.com', 'password789', 'Basic', '2023-07-20', '2024-07-20', 'User', 'token012', '2024-07-20 00:00:00'),
    ('user4@example.com', 'password101', 'Standard', '2023-09-10', '2024-09-10', 'User', 'token345', '2024-09-10 00:00:00');


INSERT INTO Payments (user_id, amount, payment_date, payment_method)
VALUES 
(1, 100.00, '2024-01-15', 'Credit Card'),
(2, 200.00, '2024-02-15', 'Bank Transfer'),
(3, 300.00, '2024-03-15', 'Cash');

INSERT INTO Subscriptions (user_id, [plan], start_date, end_date)
VALUES 
(1, 'Monthly', '2024-01-01', '2024-02-01'),
(2, 'Yearly', '2024-02-01', '2025-02-01'),
(3, 'Monthly', '2024-03-01', '2024-04-01');

INSERT INTO Courses (course_name, description)
VALUES 
('Tiếng Anh Cơ Bản', 'Khóa học tiếng Anh cơ bản dành cho người mới bắt đầu.'),
('Tiếng Anh Giao Tiếp', 'Khóa học tiếng Anh giao tiếp dành cho người đi làm.'),
('Tiếng Anh TOEIC', 'Khóa học luyện thi TOEIC với các kỹ năng cần thiết.');


INSERT INTO Topics (topic_name, course_id, description, [order])
VALUES 
('Chào hỏi', 1, 'Các mẫu câu chào hỏi thông dụng.', 1),
('Giới thiệu bản thân', 1, 'Cách giới thiệu về bản thân.', 2),
('Hội thoại văn phòng', 2, 'Các mẫu câu giao tiếp trong văn phòng.', 1),
('Luyện nghe TOEIC', 3, 'Các đoạn hội thoại luyện nghe TOEIC.', 1);

INSERT INTO Vocabularies (word, meaning, example_sentence, topic_id, pronunciation)
VALUES 
('Hello', 'Xin chào', 'Hello! How are you?', 1, 'həˈloʊ'),
('Introduce', 'Giới thiệu', 'Let me introduce myself.', 2, 'ˈɪntrəˌdjuːs'),
('Meeting', 'Cuộc họp', 'We have a meeting tomorrow.', 3, 'ˈmiːtɪŋ'),
('Listening', 'Kỹ năng nghe', 'Listening is important in TOEIC.', 4, 'ˈlɪsənɪŋ');

INSERT INTO UserProgresses (user_id, vocab_id, review_interval, last_reviewed, next_review)
VALUES 
(1, 1, 7, '2024-01-10', '2024-01-17'),  -- Người dùng 1, từ vựng 1
(1, 2, 7, '2024-01-11', '2024-01-18'),  -- Người dùng 1, từ vựng 2
(2, 3, 14, '2024-02-01', '2024-02-15'), -- Người dùng 2, từ vựng 3
(3, 4, 7, '2024-03-05', '2024-03-12'),  -- Người dùng 3, từ vựng 4
(2, 5, 10, '2024-01-20', '2024-01-30'), -- Người dùng 2, từ vựng 5
(1, 6, 5, '2024-01-15', '2024-01-20');  -- Người dùng 1, từ vựng 6


