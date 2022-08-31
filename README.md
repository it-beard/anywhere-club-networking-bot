# Anywher Club networking bot
Нетворкинг-бот клуба "Anywhere"

Через личные сообщения с помощью команды `!старт` бот опрашивает пользователя и на основании введенных пользователем данных публикует карточку с данными. Публикация происходит в заданый канал. Пользователь получает роль, которая позволяет просматривать этот канал.

Построен на базе библиотеки `Discord .NET` (https://discordnet.dev) с использованием модальных окон, команд и Interaction Framework.

Пререквизиты:
- Роль бота на сервере должна быть выше роли, которую выдает бот (роль доступа к каналу с карточками)
- Bot scope: `bot` (https://discord.com/developers/applications)
- Bot permissions: `Administrator`(https://discord.com/developers/applications)
- Server Members Intent: enabled (https://discord.com/developers/applications)
