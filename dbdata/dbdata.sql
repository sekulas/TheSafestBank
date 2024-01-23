--
-- PostgreSQL database cluster dump
--

-- Started on 2024-01-23 23:11:43

SET default_transaction_read_only = off;

SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;

--
-- Roles
--

CREATE ROLE "thesafestbank-server";
ALTER ROLE "thesafestbank-server" WITH SUPERUSER INHERIT CREATEROLE CREATEDB LOGIN REPLICATION BYPASSRLS;

--
-- User Configurations
--








--
-- Databases
--

--
-- Database "template1" dump
--

\connect template1

--
-- PostgreSQL database dump
--

-- Dumped from database version 16.1 (Debian 16.1-1.pgdg120+1)
-- Dumped by pg_dump version 16.1

-- Started on 2024-01-23 23:11:43

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

-- Completed on 2024-01-23 23:11:45

--
-- PostgreSQL database dump complete
--

--
-- Database "postgres" dump
--

\connect postgres

--
-- PostgreSQL database dump
--

-- Dumped from database version 16.1 (Debian 16.1-1.pgdg120+1)
-- Dumped by pg_dump version 16.1

-- Started on 2024-01-23 23:11:45

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

-- Completed on 2024-01-23 23:11:46

--
-- PostgreSQL database dump complete
--

--
-- Database "thesafestbankdb" dump
--

--
-- PostgreSQL database dump
--

-- Dumped from database version 16.1 (Debian 16.1-1.pgdg120+1)
-- Dumped by pg_dump version 16.1

-- Started on 2024-01-23 23:11:46

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 3396 (class 1262 OID 16384)
-- Name: thesafestbankdb; Type: DATABASE; Schema: -; Owner: thesafestbank-server
--

CREATE DATABASE thesafestbankdb WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'en_US.utf8';


ALTER DATABASE thesafestbankdb OWNER TO "thesafestbank-server";

\connect thesafestbankdb

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 217 (class 1259 OID 24588)
-- Name: Addresses; Type: TABLE; Schema: public; Owner: thesafestbank-server
--

CREATE TABLE public."Addresses" (
    "Id" uuid NOT NULL,
    "Country" text NOT NULL,
    "City" text NOT NULL,
    "Street" text NOT NULL,
    "HouseNumber" text NOT NULL,
    "ZipCode" text NOT NULL,
    "BankClientId" uuid NOT NULL
);


ALTER TABLE public."Addresses" OWNER TO "thesafestbank-server";

--
-- TOC entry 216 (class 1259 OID 24581)
-- Name: BankClients; Type: TABLE; Schema: public; Owner: thesafestbank-server
--

CREATE TABLE public."BankClients" (
    "Id" uuid NOT NULL,
    "ClientNumber" text NOT NULL,
    "AccountNumber" text NOT NULL,
    "Balance" numeric NOT NULL,
    "Name" text NOT NULL,
    "Surname" text NOT NULL,
    "PESEL" text NOT NULL,
    "Email" text NOT NULL,
    "AddressId" uuid NOT NULL,
    "LoginAttempts" integer NOT NULL,
    "IsBlocked" boolean NOT NULL,
    "PasswordResetAttempts" integer NOT NULL,
    "LastPasswordResetRequestTime" timestamp with time zone,
    "PasswordResetTokenHash" bytea,
    "IdentityCardId" uuid NOT NULL,
    "Salt" bytea NOT NULL
);


ALTER TABLE public."BankClients" OWNER TO "thesafestbank-server";

--
-- TOC entry 218 (class 1259 OID 24600)
-- Name: ClientTransactions; Type: TABLE; Schema: public; Owner: thesafestbank-server
--

CREATE TABLE public."ClientTransactions" (
    "Id" uuid NOT NULL,
    "SenderId" uuid NOT NULL,
    "SenderName" text NOT NULL,
    "SenderSurname" text NOT NULL,
    "SenderAccountNumber" text NOT NULL,
    "RecipientId" uuid NOT NULL,
    "RecipientName" text NOT NULL,
    "RecipientSurname" text NOT NULL,
    "RecipientAccountNumber" text NOT NULL,
    "Amount" numeric NOT NULL,
    "Time" timestamp with time zone NOT NULL,
    "Title" text NOT NULL,
    "BankClientId" uuid
);


ALTER TABLE public."ClientTransactions" OWNER TO "thesafestbank-server";

--
-- TOC entry 219 (class 1259 OID 24612)
-- Name: IdentityCards; Type: TABLE; Schema: public; Owner: thesafestbank-server
--

CREATE TABLE public."IdentityCards" (
    "Id" uuid NOT NULL,
    "Type" text NOT NULL,
    "Serie" text NOT NULL,
    "Number" text NOT NULL,
    "CountryOfIssue" text NOT NULL,
    "BankClientId" uuid NOT NULL
);


ALTER TABLE public."IdentityCards" OWNER TO "thesafestbank-server";

--
-- TOC entry 220 (class 1259 OID 24624)
-- Name: PartialPasswords; Type: TABLE; Schema: public; Owner: thesafestbank-server
--

CREATE TABLE public."PartialPasswords" (
    "Id" uuid NOT NULL,
    "Mask" integer[] NOT NULL,
    "Salt" bytea NOT NULL,
    "PartialPasswordHash" bytea NOT NULL,
    "PasswordStatus" integer NOT NULL,
    "BankClientId" uuid NOT NULL
);


ALTER TABLE public."PartialPasswords" OWNER TO "thesafestbank-server";

--
-- TOC entry 215 (class 1259 OID 24576)
-- Name: __EFMigrationsHistory; Type: TABLE; Schema: public; Owner: thesafestbank-server
--

CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);


ALTER TABLE public."__EFMigrationsHistory" OWNER TO "thesafestbank-server";

--
-- TOC entry 3387 (class 0 OID 24588)
-- Dependencies: 217
-- Data for Name: Addresses; Type: TABLE DATA; Schema: public; Owner: thesafestbank-server
--

COPY public."Addresses" ("Id", "Country", "City", "Street", "HouseNumber", "ZipCode", "BankClientId") FROM stdin;
32ba2f74-d94f-4057-9f59-00695817c0df	Poland	kcrv6nTPjbpz7eWFDfRujg==	PcsLAIgh/z5BP9JAb8I8Iw==	O0HgYCAq0H1+ZpmsiNG9bg==	LJNNTRvAN/nkr32ig0eA3A==	46d2048f-7de1-47f1-9163-e1b084b65cde
4717c16f-7cb8-4dda-ba6e-109d403087bb	Poland	mJ5sYmRqoeMbJu9LpEsVvA==	ICGuFKbIpa1ddyKrrWumqw==	/g/bQOajO8SBrXeRBPFa5g==	cCJ6O70OvyIOkAwx8hiK7g==	1e1dab8d-9625-4262-8f46-bc43ac58b2c0
a2c9fb28-562c-42c7-851b-60e638a6adf8	Poland	mOvPrseSYjD1A0u8yObUDQ==	+fvxX45GKJX1KMO8gpiKXA==	8JbUpT4Gs1cX5NqRjT+7gQ==	i4glfOOTvzjR+RKx289LgQ==	0dadb77d-9c27-4bd8-b1e3-c642b159f02d
\.


--
-- TOC entry 3386 (class 0 OID 24581)
-- Dependencies: 216
-- Data for Name: BankClients; Type: TABLE DATA; Schema: public; Owner: thesafestbank-server
--

COPY public."BankClients" ("Id", "ClientNumber", "AccountNumber", "Balance", "Name", "Surname", "PESEL", "Email", "AddressId", "LoginAttempts", "IsBlocked", "PasswordResetAttempts", "LastPasswordResetRequestTime", "PasswordResetTokenHash", "IdentityCardId", "Salt") FROM stdin;
0dadb77d-9c27-4bd8-b1e3-c642b159f02d	223456789012	22345678901234567890123456	1000.0	Bob	Bobkins	9Idi5/KqVaNkqHqZH3R4HA==	bob.bobkins@gmail.com	a2c9fb28-562c-42c7-851b-60e638a6adf8	0	f	0	\N	\N	c424201b-3df6-4e3d-aa35-d244dedd47da	\\x221247e9bd02e9048cc1e25a23af76e6
1e1dab8d-9625-4262-8f46-bc43ac58b2c0	323456789012	32345678901234567890123456	1000.0	Scott	Scottkins	oiyRFHB+LcV52o4DGcBZTA==	scotty123@gmail.com	4717c16f-7cb8-4dda-ba6e-109d403087bb	0	f	0	\N	\N	2bded43b-d53c-42fd-b425-57e746dec85c	\\x8a03b193adc08854f55f7e04ff8ba134
46d2048f-7de1-47f1-9163-e1b084b65cde	123456789012	12345678901234567890123456	1000.0	Sebastian	Sekula	J4PiiRf7uI9DujNSUzN1MA==	sekula.sebastian.kontakt@gmail.com	32ba2f74-d94f-4057-9f59-00695817c0df	0	f	0	\N	\N	c87c6e1f-abd6-4c3c-9a5b-20a2e6f9b5c5	\\xb336e339f4626100cac948a27f8fd586
\.


--
-- TOC entry 3388 (class 0 OID 24600)
-- Dependencies: 218
-- Data for Name: ClientTransactions; Type: TABLE DATA; Schema: public; Owner: thesafestbank-server
--

COPY public."ClientTransactions" ("Id", "SenderId", "SenderName", "SenderSurname", "SenderAccountNumber", "RecipientId", "RecipientName", "RecipientSurname", "RecipientAccountNumber", "Amount", "Time", "Title", "BankClientId") FROM stdin;
\.


--
-- TOC entry 3389 (class 0 OID 24612)
-- Dependencies: 219
-- Data for Name: IdentityCards; Type: TABLE DATA; Schema: public; Owner: thesafestbank-server
--

COPY public."IdentityCards" ("Id", "Type", "Serie", "Number", "CountryOfIssue", "BankClientId") FROM stdin;
2bded43b-d53c-42fd-b425-57e746dec85c	WCDm3fU3Wuz2tP8BtT4Na7w3/u+CrORprbtI0FGD/u4=	ZnE+YgAJMaVAaiNgxgfsfA==	46h0vavSCFWzUOkSFQ+vqA==	Poland	1e1dab8d-9625-4262-8f46-bc43ac58b2c0
c424201b-3df6-4e3d-aa35-d244dedd47da	L+E9akui4WtydSFLZXVU/KtJgSfDPRVQN7SOnbNhj1s=	Tsb0Tw3EbCUHc/2t5SkCTA==	V0GlMbyAFo3zliyMYk2ktQ==	Poland	0dadb77d-9c27-4bd8-b1e3-c642b159f02d
c87c6e1f-abd6-4c3c-9a5b-20a2e6f9b5c5	2i+vNNRDJijpUhTRHB23goxr1IsTzRG5qc4jHyY3PKY=	Ks0V+1ikP9I3B3H+Z8AeVg==	oLskBuEOtZdRkRnXBYKIPQ==	Poland	46d2048f-7de1-47f1-9163-e1b084b65cde
\.


--
-- TOC entry 3390 (class 0 OID 24624)
-- Dependencies: 220
-- Data for Name: PartialPasswords; Type: TABLE DATA; Schema: public; Owner: thesafestbank-server
--

COPY public."PartialPasswords" ("Id", "Mask", "Salt", "PartialPasswordHash", "PasswordStatus", "BankClientId") FROM stdin;
0cc20c4f-2f10-413b-8fb3-4581b6600237	{1,3,4,12,15}	\\x1a300beef335515860ba362a82e4a473	\\x3ade4a7d0965abc0b364e22fef676281fa7472cef8e66c207fbd8b70a8a6f725	1	0dadb77d-9c27-4bd8-b1e3-c642b159f02d
1863f786-4eed-4cda-8883-4c984eb7addd	{1,4,11,12,14}	\\x12c85b4a683292c3fe51f7ec2c7ae9eb	\\x8620dfc81c590e50fa8ce7258340440090d7a1f9216695cd444f2584790f4aee	1	46d2048f-7de1-47f1-9163-e1b084b65cde
19b572b7-66de-4510-a08c-2e7c9371711d	{1,6,7,8,15}	\\xadf53c29e36fd3f3687107bf871d004c	\\xcda6cb90179e48dcdcdd8aab3479d42cbc367ca83f785191e8438dd08a48a931	1	0dadb77d-9c27-4bd8-b1e3-c642b159f02d
1b1f4cb0-1a57-4bb0-988a-38252e14a35b	{1,3,11,13,14}	\\x03b7345f6868496727a83b73911a5f24	\\x448c7686aec2a9bee3ad86ff53b2a952dbb3507bbbe55ffee388495a4e76dc88	1	46d2048f-7de1-47f1-9163-e1b084b65cde
1e13ac7d-44b9-4663-8d23-9e52b0123b08	{3,5,6,8,9}	\\x471a073d15f3a6f049c6fdffb531bddc	\\x4604a91ae1cb834779df030f4b4ba334053f867b225fa1aebe1739281ef0985b	1	1e1dab8d-9625-4262-8f46-bc43ac58b2c0
276dc943-40a8-4432-bdfe-50415bdbee58	{0,1,2,3,7}	\\xb30655d4c0dd44df295deb8a754d14fc	\\x11d0c5f9e952e1e250aa7f6e492168b3536d0b2171c77a0e6340e790683ac66a	1	1e1dab8d-9625-4262-8f46-bc43ac58b2c0
2eb378f2-8f75-4d9d-8c7c-31e332f05a27	{5,6,7,8,9}	\\x7ecb4d6c87e0aa6de52911593798654d	\\x41b7cb4eae9a16158ac23923129476f5c30ea5a0101f2357c18214ddea6bf00b	1	46d2048f-7de1-47f1-9163-e1b084b65cde
316d56e8-ddfa-4681-beda-8e0f6fe2223f	{1,2,11,13,15}	\\x40a6a0d52ef6a7f2a007e74d85766a1a	\\x14ddc5506dee7f0db693ca7f76ee62d7d73c3a7f91ef6f995ece952b4158e41e	2	46d2048f-7de1-47f1-9163-e1b084b65cde
39c5065e-3ef2-4c44-848d-c8a59dbd7164	{1,5,8,10,11}	\\x0031f6f1f26f42694c4fb4a8b611999b	\\x71c955e06d39157a46fd0d574b2e4c9e1dfa6ac4f77d093c656673d75feae2b8	1	46d2048f-7de1-47f1-9163-e1b084b65cde
3c59de97-6345-4b8d-b150-6b9640282ba7	{5,6,7,13,15}	\\x9bb551fa9fa04ea16d6e32448bfeb834	\\x93fb39ff3f2db9679bb981f081e82458351f7db382deb04290416efee9c4852b	1	1e1dab8d-9625-4262-8f46-bc43ac58b2c0
4415c6ab-c261-4b1f-af3f-8c825170fae0	{0,2,5,10,13}	\\xd17fe7b9bea3d26c9c6526eea5a931f6	\\x5f14418a4fdec9f80032a96363f05b9d0ffc01e9ad4c8624be9b191db7470af5	1	46d2048f-7de1-47f1-9163-e1b084b65cde
5a51c5f0-59b0-490b-bd16-7b1142366564	{0,7,10,12,15}	\\xdc0081f556dd281d03a221a405ef4571	\\x5736d6cbf22843e41dcdd56b415a1b2fc4d0b8a31c321c17ec10a3217cac8030	1	0dadb77d-9c27-4bd8-b1e3-c642b159f02d
639021ad-2f3d-44ed-bc96-058a844a6b40	{0,4,9,10,11}	\\x48cb5ec46938d113db260c13b23c013d	\\x4dad4abde9e56e2e4313188d97839868cbb453e9e3f4b7bd781ff4e72e8ceb66	1	46d2048f-7de1-47f1-9163-e1b084b65cde
8a5dba35-4375-499e-be3e-0eee958864c6	{1,2,5,10,13}	\\x2b2967043864d32800eeabc8e922acfc	\\x411c0b9cf714024dcb231bb6588831e77818cd7f123dd4d7ab98fc1e79976041	2	1e1dab8d-9625-4262-8f46-bc43ac58b2c0
94f7308c-d770-4349-b249-dfc111d2b072	{2,4,6,7,12}	\\x06ca9e336baa18c591ab22cc0512cc32	\\x96aee942386126c1fad5c04c459bdad55c9c114dfc16ee85b479906481dbc1a2	1	1e1dab8d-9625-4262-8f46-bc43ac58b2c0
a862a697-2195-4fa1-9930-01524abd558c	{7,8,11,12,15}	\\xbe45eba4defb2e951c2bb14d65d03e50	\\x0d1de5eaaa894a16c7224ccf31d64fc5fd40dda580bc022f09e3fc2f816dd8f3	1	46d2048f-7de1-47f1-9163-e1b084b65cde
aa1b7aa0-291c-4f53-a4ac-2302834f77f0	{2,7,10,14,15}	\\x68944d6415fea8dcc196f215fc2f154c	\\x9004dbf0741139a2eac021317c854f0e2f94486e7a45522a57d6f1daa110694b	1	1e1dab8d-9625-4262-8f46-bc43ac58b2c0
aa23d1ac-f36e-4db1-84f7-1b617894e1c5	{1,7,9,10,11}	\\xf13cbcde7f9629ad07fba27b6da4c85f	\\xcb4e80cc5ee7877a65647dd8efee8035b849ba74dc7b6e8caf429a60d5e5121a	1	1e1dab8d-9625-4262-8f46-bc43ac58b2c0
b1001258-dac9-4749-9f0d-089aaf5b7701	{4,6,10,13,15}	\\x3c4a9fa0dbb869eb59bfe79f3c3ba548	\\xf26b4b3c144c7d76cde56a546c388b58c1b1f637dcd758e4ac06d79ae70ce1e7	1	0dadb77d-9c27-4bd8-b1e3-c642b159f02d
b4a55758-6e9d-4cc9-a6dc-35a4794280fa	{0,2,3,8,12}	\\xb48587830b54d5244727192a2ad80066	\\xb81ce1894d4e9302343303a5737231adfbf396ef6e0e3a7f12693e34fdffcdd9	1	0dadb77d-9c27-4bd8-b1e3-c642b159f02d
bbffdadc-3d65-4552-91f8-9f5bfb1eb5fd	{3,4,7,11,12}	\\x32620dd581b79807b80e0532cddef636	\\x50f4383ea4391a0d49bfb0ca774262dc854a1fd66643a85b0bfc1f32f883294c	1	46d2048f-7de1-47f1-9163-e1b084b65cde
c4f6a99d-6dfa-4b65-88be-8c33a9755f9a	{9,10,12,13,14}	\\xdcfd0c896e77926e6559af7a69020fb6	\\x1ed2971ed58620c8d6beefb56a8d7039f2c9c18babf055b2d987f64a4736230f	1	1e1dab8d-9625-4262-8f46-bc43ac58b2c0
c943c6ae-6cd0-4636-a7f1-ea8b96df2f15	{1,4,5,11,12}	\\x56246e732af44febe84e2cbe3469ddba	\\x12789a800934cd12e34f18d73a1a0fee88d3400c77c60e6cd7e460d2083a1efc	1	1e1dab8d-9625-4262-8f46-bc43ac58b2c0
e008fcb0-ac3e-41bc-b486-72c706266a3a	{0,2,3,11,14}	\\x14a70ae65633b9704c183255cf99d4fb	\\x7ecb7e079d5953a637eb22dde8a8308e2523640c82fa9d4637fe166e5aa97378	1	46d2048f-7de1-47f1-9163-e1b084b65cde
e3e76270-7b6d-4e52-ba32-31c08353beaa	{1,5,6,9,15}	\\xb43a4f1bb9e8be9798f6c38616a3f64c	\\x80929e6daea0a0f65452062625ea6fd05b342c23cf0c58b51353bc2dbf1485cb	1	0dadb77d-9c27-4bd8-b1e3-c642b159f02d
f67b4056-3e3c-40ab-9255-004487e3edba	{0,1,3,11,13}	\\xa5b109545f3defd61d4cef8c05ded271	\\x6e904386b078fb2da64fbd303e5508c231ab73210ec6d6d3bb2f48881c6e7ac6	1	1e1dab8d-9625-4262-8f46-bc43ac58b2c0
fd1e9a78-2c7c-430d-b4ba-a5bffee2bca1	{0,1,9,12,15}	\\xb8347d4a26f916d57c66436f504d6917	\\x036097dbf2d44098d232f619b730d29ca74e3a33afba0dd1090668808ddb0072	1	0dadb77d-9c27-4bd8-b1e3-c642b159f02d
fea2c52c-5c7f-49c3-8bbf-abe124eacd3a	{1,4,5,10,14}	\\xd26bdd9ce441483cfc905d404ffc7ffe	\\xeb20a36c120a2b9f3d115d8683b2030060e0cc6e49e272175fdc16e63766190b	1	0dadb77d-9c27-4bd8-b1e3-c642b159f02d
fec714ba-feb5-4876-a50b-d6a89dda6ec8	{0,2,6,7,11}	\\xb7817a1c1ff7cdff3b2842e5ba114f9f	\\x6766bd5148ae930596159701d279822dc912f5ffcddf5d37a0afacc7f79abf97	2	0dadb77d-9c27-4bd8-b1e3-c642b159f02d
ffdddb0d-4438-4b10-bc40-3b84f452c45c	{1,3,4,5,6}	\\xa6fad9f90c82cd53d2ba38efb74ae18f	\\x36df358d0c8a1f7c171e49d08a0cfe3fadbee525ca294ba3fca411d602d54634	1	0dadb77d-9c27-4bd8-b1e3-c642b159f02d
\.


--
-- TOC entry 3385 (class 0 OID 24576)
-- Dependencies: 215
-- Data for Name: __EFMigrationsHistory; Type: TABLE DATA; Schema: public; Owner: thesafestbank-server
--

COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
20240123173447_ProductionMigration	8.0.0
\.


--
-- TOC entry 3228 (class 2606 OID 24594)
-- Name: Addresses PK_Addresses; Type: CONSTRAINT; Schema: public; Owner: thesafestbank-server
--

ALTER TABLE ONLY public."Addresses"
    ADD CONSTRAINT "PK_Addresses" PRIMARY KEY ("Id");


--
-- TOC entry 3225 (class 2606 OID 24587)
-- Name: BankClients PK_BankClients; Type: CONSTRAINT; Schema: public; Owner: thesafestbank-server
--

ALTER TABLE ONLY public."BankClients"
    ADD CONSTRAINT "PK_BankClients" PRIMARY KEY ("Id");


--
-- TOC entry 3231 (class 2606 OID 24606)
-- Name: ClientTransactions PK_ClientTransactions; Type: CONSTRAINT; Schema: public; Owner: thesafestbank-server
--

ALTER TABLE ONLY public."ClientTransactions"
    ADD CONSTRAINT "PK_ClientTransactions" PRIMARY KEY ("Id");


--
-- TOC entry 3234 (class 2606 OID 24618)
-- Name: IdentityCards PK_IdentityCards; Type: CONSTRAINT; Schema: public; Owner: thesafestbank-server
--

ALTER TABLE ONLY public."IdentityCards"
    ADD CONSTRAINT "PK_IdentityCards" PRIMARY KEY ("Id");


--
-- TOC entry 3237 (class 2606 OID 24630)
-- Name: PartialPasswords PK_PartialPasswords; Type: CONSTRAINT; Schema: public; Owner: thesafestbank-server
--

ALTER TABLE ONLY public."PartialPasswords"
    ADD CONSTRAINT "PK_PartialPasswords" PRIMARY KEY ("Id");


--
-- TOC entry 3223 (class 2606 OID 24580)
-- Name: __EFMigrationsHistory PK___EFMigrationsHistory; Type: CONSTRAINT; Schema: public; Owner: thesafestbank-server
--

ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");


--
-- TOC entry 3226 (class 1259 OID 24636)
-- Name: IX_Addresses_BankClientId; Type: INDEX; Schema: public; Owner: thesafestbank-server
--

CREATE UNIQUE INDEX "IX_Addresses_BankClientId" ON public."Addresses" USING btree ("BankClientId");


--
-- TOC entry 3229 (class 1259 OID 24637)
-- Name: IX_ClientTransactions_BankClientId; Type: INDEX; Schema: public; Owner: thesafestbank-server
--

CREATE INDEX "IX_ClientTransactions_BankClientId" ON public."ClientTransactions" USING btree ("BankClientId");


--
-- TOC entry 3232 (class 1259 OID 24638)
-- Name: IX_IdentityCards_BankClientId; Type: INDEX; Schema: public; Owner: thesafestbank-server
--

CREATE UNIQUE INDEX "IX_IdentityCards_BankClientId" ON public."IdentityCards" USING btree ("BankClientId");


--
-- TOC entry 3235 (class 1259 OID 24639)
-- Name: IX_PartialPasswords_BankClientId; Type: INDEX; Schema: public; Owner: thesafestbank-server
--

CREATE INDEX "IX_PartialPasswords_BankClientId" ON public."PartialPasswords" USING btree ("BankClientId");


--
-- TOC entry 3238 (class 2606 OID 24595)
-- Name: Addresses FK_Addresses_BankClients_BankClientId; Type: FK CONSTRAINT; Schema: public; Owner: thesafestbank-server
--

ALTER TABLE ONLY public."Addresses"
    ADD CONSTRAINT "FK_Addresses_BankClients_BankClientId" FOREIGN KEY ("BankClientId") REFERENCES public."BankClients"("Id") ON DELETE CASCADE;


--
-- TOC entry 3239 (class 2606 OID 24607)
-- Name: ClientTransactions FK_ClientTransactions_BankClients_BankClientId; Type: FK CONSTRAINT; Schema: public; Owner: thesafestbank-server
--

ALTER TABLE ONLY public."ClientTransactions"
    ADD CONSTRAINT "FK_ClientTransactions_BankClients_BankClientId" FOREIGN KEY ("BankClientId") REFERENCES public."BankClients"("Id");


--
-- TOC entry 3240 (class 2606 OID 24619)
-- Name: IdentityCards FK_IdentityCards_BankClients_BankClientId; Type: FK CONSTRAINT; Schema: public; Owner: thesafestbank-server
--

ALTER TABLE ONLY public."IdentityCards"
    ADD CONSTRAINT "FK_IdentityCards_BankClients_BankClientId" FOREIGN KEY ("BankClientId") REFERENCES public."BankClients"("Id") ON DELETE CASCADE;


--
-- TOC entry 3241 (class 2606 OID 24631)
-- Name: PartialPasswords FK_PartialPasswords_BankClients_BankClientId; Type: FK CONSTRAINT; Schema: public; Owner: thesafestbank-server
--

ALTER TABLE ONLY public."PartialPasswords"
    ADD CONSTRAINT "FK_PartialPasswords_BankClients_BankClientId" FOREIGN KEY ("BankClientId") REFERENCES public."BankClients"("Id") ON DELETE CASCADE;


-- Completed on 2024-01-23 23:11:46

--
-- PostgreSQL database dump complete
--

-- Completed on 2024-01-23 23:11:46

--
-- PostgreSQL database cluster dump complete
--

