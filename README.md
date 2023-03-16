
drop table user_info;
CREATE TABLE IF NOT EXISTS user_info (
  id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
  full_name varchar(250) NOT NULL,
  username varchar(250) NOT NULL,
  email varchar(250) NOT NULL UNIQUE,
  type varchar(50) NOT NULL,
  create_date timestamp without time zone default (now() at time zone 'utc'),
  update_date timestamp without time zone default (now() at time zone 'utc'),
  cash_balance float NOT NULL
);




INSERT INTO public.user_info(
	full_name, username, email, type,cash_balance)
	VALUES ('John','JohnMary','johnmary@gmail.com','user',450.9090);


drop table user_order;
CREATE TABLE IF NOT EXISTS user_order (
	id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	user_id INT NOT NULL,
	stock_id INT NOT NULL,
	order_nature varchar(250) NOT NULL,
	quantity INT NOT NULL,
	status varchar(250) NOT NULL,
	status_reason varchar(250) NOT NULL,
	order_type varchar(250) NOT NULL,
	limit_price float,
	limit_expiration INT,
	transaction_execution_price float,
	create_dt timestamp without time zone default (now() at time zone 'utc'),
	update_dt timestamp without time zone default (now() at time zone 'utc')

	
);
INSERT INTO public.user_order(
	user_id, stock_id, order_nature, quantity, status, status_reason, order_type, limit_price, limit_expiration, transaction_execution_price)
	VALUES (1, 1,'Buy', 20, 'Pending', 'Order will place on 20th', 'Limit', 500, 7, 800);

drop table stock;
CREATE TABLE IF NOT EXISTS stock (
  id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
  ticker varchar(20) NOT NULL,
  initial_price float NOT NULL,
  company_name varchar(250) NOT NULL,
  volume INT NOT NULL,
  current_price float NOT NULL
  	
);
INSERT INTO public.stock(
	ticker, initial_price, company_name, volume, current_price)
	VALUES ('AAPL', 400.00, 'Apple', 500, 500.00);

drop table user_stock;
CREATE TABLE IF NOT EXISTS user_stock (
	id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	user_id INT NOT NULL,
	stock_id INT NOT NULL,
	quantity INT NOT NULL,
	update_dt timestamp without time zone default (now() at time zone 'utc'),
	UNIQUE (user_id, stock_id)

	
);
INSERT INTO public.user_stock(
	user_id, stock_id, quantity)
	VALUES (1, 1, 500);
