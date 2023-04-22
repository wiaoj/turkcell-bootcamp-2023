CREATE TABLE "books_authors"(
    "book_id" BIGINT NOT NULL,
    "author_id" BIGINT NOT NULL
);
ALTER TABLE
    "books_authors" ADD CONSTRAINT "books_authors_book_id_primary" PRIMARY KEY("book_id");
ALTER TABLE
    "books_authors" ADD CONSTRAINT "books_authors_author_id_primary" PRIMARY KEY("author_id");
CREATE TABLE "books"(
    "id" BIGINT NOT NULL,
    "title" NVARCHAR(250) NOT NULL,
    "publication_date" DATE NOT NULL,
    "isbn" NVARCHAR(20) NOT NULL
);
ALTER TABLE
    "books" ADD CONSTRAINT "books_id_primary" PRIMARY KEY("id");
CREATE TABLE "reviews"(
    "id" BIGINT NOT NULL,
    "user_id" BIGINT NOT NULL,
    "book_id" BIGINT NOT NULL,
    "content" VARCHAR NULL,
    "rating" INT NOT NULL,
    "review_date" DATE NOT NULL
);
ALTER TABLE
    "reviews" ADD CONSTRAINT "reviews_id_primary" PRIMARY KEY("id");
CREATE TABLE "categories"("id" BIGINT NOT NULL);
ALTER TABLE
    "categories" ADD CONSTRAINT "categories_id_primary" PRIMARY KEY("id");
CREATE TABLE "users"(
    "id" BIGINT NOT NULL,
    "username" NVARCHAR(255) NOT NULL
);
ALTER TABLE
    "users" ADD CONSTRAINT "users_id_primary" PRIMARY KEY("id");
CREATE TABLE "books_categories"(
    "book_id" BIGINT NOT NULL,
    "category_id" BIGINT NOT NULL
);
ALTER TABLE
    "books_categories" ADD CONSTRAINT "books_categories_book_id_primary" PRIMARY KEY("book_id");
ALTER TABLE
    "books_categories" ADD CONSTRAINT "books_categories_category_id_primary" PRIMARY KEY("category_id");
CREATE TABLE "authors"(
    "id" BIGINT NOT NULL,
    "first_name" NVARCHAR(255) NOT NULL,
    "last_name" NVARCHAR(255) NOT NULL,
    "biography" NVARCHAR(255) NOT NULL
);
ALTER TABLE
    "authors" ADD CONSTRAINT "authors_id_primary" PRIMARY KEY("id");
ALTER TABLE
    "books_categories" ADD CONSTRAINT "books_categories_category_id_foreign" FOREIGN KEY("category_id") REFERENCES "categories"("id");
ALTER TABLE
    "reviews" ADD CONSTRAINT "reviews_user_id_foreign" FOREIGN KEY("user_id") REFERENCES "users"("id");
ALTER TABLE
    "books_authors" ADD CONSTRAINT "books_authors_author_id_foreign" FOREIGN KEY("author_id") REFERENCES "authors"("id");
ALTER TABLE
    "books_authors" ADD CONSTRAINT "books_authors_book_id_foreign" FOREIGN KEY("book_id") REFERENCES "books"("id");
ALTER TABLE
    "books_categories" ADD CONSTRAINT "books_categories_book_id_foreign" FOREIGN KEY("book_id") REFERENCES "books"("id");
ALTER TABLE
    "reviews" ADD CONSTRAINT "reviews_book_id_foreign" FOREIGN KEY("book_id") REFERENCES "books"("id");