Важно! - Преди да стартираш за първи път услугата, промени ConnectionString-a в appsetings.json спрямо своя сървър.

Използвани технологии при реализирането на service-a:

- Worker Service
- Entity Framework
- SQL Server

- за съхраняване на данните използвам MSSQL server, предпочетох го, защото съм работил и преди с него.
- за ORM използвах Entity Framework, свикнал съм с него да работя, удобен е при писането на заявки, при създаването на базата данни. Има много вградени методи, които ме улесняват.

- след разучаване на темата background processing предпочетох да използвам worker service, което ми предлага visual studio. Готов шаблон за процеси на заден план.
- не ми стигна времето да имплементирам филтриране на резултата по име на щат.

- използвал съм dependency injection - с цел по-лесно тестване, по-лесно разширяване в бъдеще, и да са по-слабо свързани класовете помежду си.

- използвал съм Repository-Service Pattern - услугите се занимават с бизнес логиката и в тях се инжекват репозиторитата, докато последните се занимават с обработването на данни към базата и от базата.

- Затруднения, които имах със задачата, но които разреших:

1. Избор на технология, с която да управлявам процеси на заден план.
2. След получаване на response от REST WebService десериализирането на нужните полета само към обект.
3. Инжектването на scope service в singleton service, т.е използването на сървис с по-къс живот в сървис с по-дълъг живот.