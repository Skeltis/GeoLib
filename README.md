# Тестовое задание 3
> В базе данных MS SQL Server есть статьи и тэги. Одной статье может соответствовать много тэгов, а тэгу — много статей. Напишите SQL запрос для выбора всех пар «Тема статьи – тэг». Если у статьи нет тэгов, то её тема всё равно должна выводиться.

**SELECT** articles.article_name, tags.tag_name  
**FROM** (articles **LEFT JOIN** taggedarticles **USING** (article_id)) **LEFT JOIN** tags **USING** (tag_id);
