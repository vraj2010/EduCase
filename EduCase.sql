PGDMP                         {            EduCase    15.4    15.4     	           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            
           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false                       0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false                       1262    24693    EduCase    DATABASE     |   CREATE DATABASE "EduCase" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'English_India.1252';
    DROP DATABASE "EduCase";
                postgres    false            �            1259    24694 
   t_standard    TABLE     y   CREATE TABLE public.t_standard (
    s_standardid integer NOT NULL,
    s_standardname character varying(50) NOT NULL
);
    DROP TABLE public.t_standard;
       public         heap    postgres    false            �            1259    24697 	   t_student    TABLE     �  CREATE TABLE public.t_student (
    s_id integer NOT NULL,
    s_name character varying(50) NOT NULL,
    s_dob date NOT NULL,
    s_gender character varying(6) NOT NULL,
    s_mob character varying(10) NOT NULL,
    s_email character varying(320) NOT NULL,
    s_cricket boolean NOT NULL,
    s_volleyball boolean NOT NULL,
    s_gaming boolean NOT NULL,
    s_address character varying(200) NOT NULL,
    s_standardid integer
);
    DROP TABLE public.t_student;
       public         heap    postgres    false            �            1259    24702    t_student_s_id_seq    SEQUENCE     �   ALTER TABLE public.t_student ALTER COLUMN s_id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.t_student_s_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    215            �            1259    24703    t_user    TABLE     �   CREATE TABLE public.t_user (
    t_userid integer NOT NULL,
    t_username character varying(50) NOT NULL,
    t_email character varying(320) NOT NULL,
    t_password character varying(50) NOT NULL
);
    DROP TABLE public.t_user;
       public         heap    postgres    false            �            1259    24706    t_user_t_userid_seq    SEQUENCE     �   ALTER TABLE public.t_user ALTER COLUMN t_userid ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.t_user_t_userid_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    217                      0    24694 
   t_standard 
   TABLE DATA           B   COPY public.t_standard (s_standardid, s_standardname) FROM stdin;
    public          postgres    false    214                     0    24697 	   t_student 
   TABLE DATA           �   COPY public.t_student (s_id, s_name, s_dob, s_gender, s_mob, s_email, s_cricket, s_volleyball, s_gaming, s_address, s_standardid) FROM stdin;
    public          postgres    false    215   t                 0    24703    t_user 
   TABLE DATA           K   COPY public.t_user (t_userid, t_username, t_email, t_password) FROM stdin;
    public          postgres    false    217   �                  0    0    t_student_s_id_seq    SEQUENCE SET     @   SELECT pg_catalog.setval('public.t_student_s_id_seq', 8, true);
          public          postgres    false    216                       0    0    t_user_t_userid_seq    SEQUENCE SET     A   SELECT pg_catalog.setval('public.t_user_t_userid_seq', 2, true);
          public          postgres    false    218            o           2606    24708    t_standard t_standard_pkey 
   CONSTRAINT     b   ALTER TABLE ONLY public.t_standard
    ADD CONSTRAINT t_standard_pkey PRIMARY KEY (s_standardid);
 D   ALTER TABLE ONLY public.t_standard DROP CONSTRAINT t_standard_pkey;
       public            postgres    false    214            q           2606    24710    t_student t_student_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public.t_student
    ADD CONSTRAINT t_student_pkey PRIMARY KEY (s_id);
 B   ALTER TABLE ONLY public.t_student DROP CONSTRAINT t_student_pkey;
       public            postgres    false    215            s           2606    24712    t_user t_user_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public.t_user
    ADD CONSTRAINT t_user_pkey PRIMARY KEY (t_userid);
 <   ALTER TABLE ONLY public.t_user DROP CONSTRAINT t_user_pkey;
       public            postgres    false    217               d   x�-�K@@D�Շ�� ,m�ҎA'B2����X���K1jq�����u�f7P�z;��)UcTfh�V�j�v�T��IY���s�̨�_�����D� K+ S         s  x�e��N�0��O�����;g�^��ɮ�9�	݀��a|{Oa�sa7K>�}�;�@����MQg3���fF�&/���)�#rU���۾���Y��;
B&���j����Ɉ6�j2ZQ*FX	È�LI�����1PB$��o<�9�E?B�p�iG%Z[Z�e�2ڞH���>:�u�q�J.f���5U5N�"Cş_����(��̞�c�mw{��D�MM�C�;r��Wf2?M`�VFh]���j"e~6C|��G;�(�)
^�w4��S�nkVBqo�,�;�!�x���p|�cp	���ԥ�|�'5��\m��Bi�r�ְa4���nG����|�W����Û�є�������-.�kj�U�,�$�Tk�\         U   x�3�+J�RH,I��,2��L�s3s���s�*�@\F�a�%ŉ9
��)��e`v.�id��,�al`����� M��     