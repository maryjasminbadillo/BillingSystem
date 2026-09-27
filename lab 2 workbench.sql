-- Create the BillingDB database
CREATE DATABASE IF NOT EXISTS BillingDB;
 
-- Switch to using BillingDB for all following commands
USE BillingDB;

USE BillingDB;
 
CREATE TABLE IF NOT EXISTS Users (
    UserID     INT          NOT NULL AUTO_INCREMENT,
    Username   VARCHAR(50)  NOT NULL UNIQUE,
    Password   VARCHAR(255) NOT NULL,
    FullName   VARCHAR(150) NOT NULL,
    Role       VARCHAR(20)  NOT NULL DEFAULT 'Staff',
    CreatedAt  DATETIME     NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT pk_Users PRIMARY KEY (UserID)
);
 
-- Insert a default admin account for testing
INSERT INTO Users (Username, Password, FullName, Role)
VALUES ('admin', 'admin123', 'Administrator', 'Admin');

