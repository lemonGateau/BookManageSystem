using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookManageSystem
{
    public static class ReservationRepository
    {
        /// <summary>
        /// 書籍を予約する
        /// </summary>
        /// <param name="isbn"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static int ReserveBook(string isbn, int userId)
        {
            using var db = new BookDBContext();

            var reservation = new Reservation { Isbn = isbn, UserId = userId, CreatedAt = DateTime.Now, StatusId = (int)StatusId.Reserved };

            db.Reservations.Add(reservation);
            db.SaveChanges();

            return reservation.ReservationId;
        }

        public static void CompleteReservation(int reservationId)
        {
            ChangeReservationStatus(reservationId, (int)StatusId.Completed);
        }

        public static void CancelReservation(int reservationId)
        {
            ChangeReservationStatus(reservationId, (int)StatusId.Cancelled);
        }

        /// <summary>
        /// 予約の状態を変更する
        /// </summary>
        /// <param name="reservationId"></param>
        /// <param name="statusId"></param>
        private static void ChangeReservationStatus(int reservationId, int statusId)
        {
            using var db = new BookDBContext();

            var reservation = db.Reservations.Find(reservationId);

            if (reservation != null)
            {
                reservation.StatusId = statusId;

                db.SaveChanges();
            }
        }

        public static List<Reservation> GetReservations(string? isbn = null, int? userId = null, int? statusId = null)
        {
            using var db = new BookDBContext();

            IQueryable<Reservation> query = db.Reservations;

            // 条件で絞り込み
            if (isbn != null)       query = query.Where(r => r.Isbn == isbn);
            if (userId != null)     query = query.Where(r => r.UserId == userId);
            if (statusId != null)   query = query.Where(r => r.StatusId == statusId);

            return query.OrderByDescending(r => r.ReservationId).ToList();
        }

        /// <summary>
        /// 予約情報ビューを取得する
        /// </summary>
        /// <param name="statusId"></param>
        /// <returns></returns>
        public static List<ReservationView> GetReservationViews(string? isbn = null, int? userId = null, int? statusId = null)
        {
            using var db = new BookDBContext();

            var query = db.Reservations.Select(r => new ReservationView
            {
                ReservationId = r.ReservationId,
                Isbn          = r.Isbn,
                UserId        = r.UserId,
                Title         = r.Book.Title,
                PublisherName = r.Book.Publisher.Name,
                CategoryName  = r.Book.Category.Name,
                CreatedAt     = r.CreatedAt,
                StatusId      = r.StatusId,
                StatusName    = r.ReservationStatus.Name
            });

            // 条件で絞り込み
            if (isbn != null)       query = query.Where(r => r.Isbn == isbn);
            if (userId != null)     query = query.Where(r => r.UserId == userId);
            if (statusId != null)   query = query.Where(r => r.StatusId == statusId);

            return query.OrderByDescending(r => r.ReservationId).ToList();
        }
    }
}
