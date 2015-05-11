using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bezier
{
    public partial class MainForm : Form
    {
        const int x_size = 1000;
        const int y_size = 1000;
        const int x_center = (int)(x_size * .5);
        const int y_center = (int)(y_size * .5);
        Bitmap bmp = new Bitmap(x_size, y_size);
        Point point_center = new Point(x_center, y_center);


        List<Point> points = new List<Point>();
        List<Point> fixed_points = new List<Point>();
        Pen pen = new Pen(Color.Navy);
        const int circle_radius = 150;
        Rectangle rect = new Rectangle(x_center - circle_radius, y_center - circle_radius, 2 * circle_radius, 2 * circle_radius);

        Color point_color = Color.Red;

        Pen rotate_pen = new Pen(Color.Navy, 5);
        Pen zoom_pen = new Pen(Color.Navy, 5);
        Pen move_pen = new Pen(Color.Navy, 5);

        Point move_center;
        List<Point> points_from_center = new List<Point>();

        double x_zoom, y_zoom;

        bool rotate = false;
        bool zoom = false;
        bool move = false;

        const int rotate_lines_len = 40;
        const int zoom_lines_half_len = 20;
        const int zoom_lines_offset = 10;

        const int move_lines_offset = 10;
        const int point_size = 3;

        public MainForm()
        {
            InitializeComponent();
        }

        int fact(int n)
        {
            int res = 1;
            for (int i = 1; i <= n; i++)
                res *= i;
            return res;
        }

        double coef(int i, int n, double t)
        {
            return fact(n) / (double)(fact(i) * fact(n - i)) * Math.Pow(1 - t, n - i) * Math.Pow(t, i);
        }

        double B(double t, int p1, int p2, int p3, int p4)
        {
            return Math.Pow(1 - t, 3) * p1 + 3 * Math.Pow(1 - t, 2) * t * p2 + 3 * (1 - t) * t * t * p3 + t * t * t * p4;
        }

        void draw_curve(Bitmap bmp, Color color, List<Point> points)
        {
            if (2 <= points.Count)
                for (double t = 0; t <= 1; t += 0.00001)
                {
                    double x = 0;
                    double y = 0;
                    for (int i = 0; i < points.Count; i++)
                    {
                        double coef_i = coef(i, points.Count - 1, t);
                        x += coef_i * points[i].X;
                        y += coef_i * points[i].Y;
                    }

                    bmp.SetPixel((int)x, (int)y, color);
                }
        }

        void draw_curve_4(Bitmap bmp, Color color, int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4)
        {
            for (double t = 0; t <= 1; t += 0.00001)
                bmp.SetPixel((int)B(t, x1, x2, x3, x4), (int)B(t, y1, y2, y3, y4), color);
        }

        void draw_curve_4(Bitmap bmp, Color color, List<Point> points)
        {
            if (points.Count == 4)
            {
                // 4 dots
                for (double t = 0; t <= 1; t += 0.00001)
                    bmp.SetPixel((int)B(t, points[0].X, points[1].X, points[2].X, points[3].X), (int)B(t, points[0].Y, points[1].Y, points[2].Y, points[3].Y), color);
            }
            else
                // Many ines
                if (points.Count % 4 == 0)
                    for (int i = 0; i < points.Count; i += 4)
                        for (double t = 0; t <= 1; t += 0.00001)
                            bmp.SetPixel((int)B(t, points[i].X, points[i + 1].X, points[i + 2].X, points[i + 3].X), (int)B(t, points[i + 0].Y, points[i + 1].Y, points[i + 2].Y, points[i + 3].Y), color);
                else
                    // One line
                    if ((points.Count - 4) % 3 == 0)
                        for (int i = 0; i <= points.Count - 4; i += 3)
                            for (double t = 0; t <= 1; t += 0.00001)
                                bmp.SetPixel((int)B(t, points[i].X, points[i + 1].X, points[i + 2].X, points[i + 3].X), (int)B(t, points[i + 0].Y, points[i + 1].Y, points[i + 2].Y, points[i + 3].Y), color);
                    else
                        MessageBox.Show("Wrong dots number");

        }

        void draw()
        {
            if (cbox4.Checked == true)
                draw_curve_4(bmp, Color.Black, points);
            else
                draw_curve(bmp, Color.Black, points);
        }

        private void bDraw_Click(object sender, EventArgs e)
        {
            bRotate.Enabled = true;
            bZoom.Enabled = true;
            bMove.Enabled = true;

            bmp = new Bitmap(x_size, y_size);
            draw_points(points, bmp);
            draw();

            pbox.Image = bmp;
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                bmp.Save(saveFileDialog.FileName);
        }

        void draw_point(Point point, Bitmap bmp, Color color, int size)
        {
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    bmp.SetPixel(point.X + i, point.Y + j, color);
                    bmp.SetPixel(point.X - i, point.Y - j, color);
                    bmp.SetPixel(point.X + i, point.Y - j, color);
                    bmp.SetPixel(point.X - i, point.Y + j, color);
                }
        }

        void draw_points(List<Point> points, Bitmap bmp)
        {
            for (int i = 0; i < points.Count; i++)
                draw_point(points[i], bmp, point_color, 3);
        }

        private void pbox_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouse_events = (MouseEventArgs)e;
            Point coords = new Point(mouse_events.X, mouse_events.Y + 300);

            if (rotate)
            {
                rotate = false;

                bmp = new Bitmap(x_size, y_size);
                draw_points(points, bmp);
                draw();

                cboxRotateCurve.Enabled = false;
                tA.Enabled = false;
                tA.Text = "";
                tAgrads.Enabled = false;
                tAgrads.Text = "";
                lA.Enabled = false;
                lAgrads.Enabled = false;
            }
            else
                if (zoom)
                {
                    zoom = false;

                    bmp = new Bitmap(x_size, y_size);
                    draw_points(points, bmp);
                    draw();

                    tXZoom.Text = "";
                    tYZoom.Text = "";

                    lXZoom.Enabled = false;
                    lYZoom.Enabled = false;
                    tXZoom.Enabled = false;
                    tYZoom.Enabled = false;
                    cboxZoomCurve.Enabled = false;
                }
                else
                    if (move)
                    {
                        move = false;

                        bmp = new Bitmap(x_size, y_size);
                        draw_points(points, bmp);
                        draw();

                        tDX.Enabled = false;
                        tDY.Enabled = false;
                        lDX.Enabled = false;
                        lDY.Enabled = false;
                        cboxMoveCurve.Enabled = false;
                        tDX.Text = "";
                        tDY.Text = "";
                    }
                    else
                    {
                        draw_point(coords, bmp, point_color, 3);

                        points.Add(coords);
                        if (2 <= points.Count)
                        {
                            bDraw.Enabled = true;
                            cbox4.Enabled = true;
                            bRotate.Enabled = true;
                            bZoom.Enabled = true;
                            bMove.Enabled = true;
                        }
                    }

            pbox.Image = bmp;
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            points.Clear();
            bmp = new Bitmap(x_size, y_size);
            pbox.Image = bmp;
            bRotate.Enabled = false;
            bDraw.Enabled = false;
            cbox4.Enabled = false;
            bZoom.Enabled = false;
            rotate = false;

            zoom = false;
            lXZoom.Enabled = false;
            lYZoom.Enabled = false;
            tXZoom.Enabled = false;
            tYZoom.Enabled = false;
            cboxZoomCurve.Enabled = false;
            tXZoom.Text = "";
            tYZoom.Text = "";

            move = false;
            bMove.Enabled = false;
            tDX.Enabled = false;
            tDY.Enabled = false;
            lDX.Enabled = false;
            lDY.Enabled = false;
            cboxMoveCurve.Enabled = false;
            tDX.Text = "";
            tDY.Text = "";
        }

        void draw_initial_rotate(ref Bitmap bmp)
        {
            bmp = new Bitmap(x_size, y_size);

            Graphics g = Graphics.FromImage(bmp);
            g.DrawLine(rotate_pen, 0, y_center, rotate_lines_len, y_center);
            g.DrawLine(rotate_pen, x_size - 1 - rotate_lines_len, y_center, x_size - 1, y_center);
            g.DrawLine(rotate_pen, x_center, 300, x_center, 300 + rotate_lines_len);
            g.DrawLine(rotate_pen, x_center, y_size - 1 - 300 - rotate_lines_len, x_center, y_size - 1 - 300);

            draw_points(points, bmp);

            //g.DrawEllipse(pen, rect);
            //g.DrawLine(pen, x_center - circle_radius - 25, y_center, x_center + circle_radius + 25, y_center);
            //g.DrawLine(pen, x_center, y_center - circle_radius - 25, x_center, y_center + circle_radius + 25);
            pbox.Image = bmp;
        }

        private void bRotate_Click(object sender, EventArgs e)
        {
            rotate = true;

            cboxRotateCurve.Enabled = true;
            bDraw.Enabled = true;

            tA.Enabled = true;
            tAgrads.Enabled = true;
            lA.Enabled = true;
            lAgrads.Enabled = true;

            fixed_points = new List<Point>(points);
            draw_initial_rotate(ref bmp);
        }

        double get_alpha(Point curr_pos)
        {
            int x = curr_pos.X;
            int y = curr_pos.Y;

            double alpha = Math.Atan((y - y_center) / (double)(x - x_center));
            if (x < x_center && y < y_center)
                alpha = Math.PI + alpha;
            else
                if (x < x_center && y_center < y)
                    alpha = -(Math.PI - alpha);
            return alpha;
        }

        Point point_on_circle_old(Point curr_pos)
        {
            int x = curr_pos.X;
            int y = curr_pos.Y;

            //tX.Text = Convert.ToString(x);
            //tY.Text = Convert.ToString(y);

            double alpha = get_alpha(curr_pos);

            //tA.Text = Convert.ToString(alpha / (double)Math.PI * 180);

            int xf = x_center + (int)(circle_radius * Math.Cos(alpha));
            int yf = y_center + (int)(circle_radius * Math.Sin(alpha));
            return new Point(xf, yf);
        }

        Point point_on_circle(Point curr_pos, int R)
        {
            int x = curr_pos.X;
            int y = curr_pos.Y;

            double alpha = get_alpha(curr_pos);

            int xf = x_center + (int)(R * Math.Cos(alpha));
            int yf = y_center + (int)(R * Math.Sin(alpha));
            return new Point(xf, yf);
        }

        List<Point> rotate_points(List<Point> _points, double angle)
        {
            List<Point> ret = new List<Point>();
            for (int i = 0; i < _points.Count; i++)
            {

                int x = _points[i].X - x_center;
                int y = _points[i].Y - y_center;

                ret.Add(new Point((int)(x_center + x * Math.Cos(angle) - y * Math.Sin(angle)),
                    (int)(y_center + x * Math.Sin(angle) + y * Math.Cos(angle))));
            }
            return ret;
        }

        private void pbox_MouseMove(object sender, MouseEventArgs e)
        {
            MouseEventArgs mouse_events = (MouseEventArgs)e;
            Point coords = new Point(mouse_events.X, mouse_events.Y + 300);

            if (rotate)
            {
                double angle = get_alpha(coords);

                for (int i = 0; i < fixed_points.Count; i++)
                {

                    int x = fixed_points[i].X - x_center;
                    int y = fixed_points[i].Y - y_center;

                    points[i] = (new Point((int)(x_center + x * Math.Cos(angle) - y * Math.Sin(angle)),
                        (int)(y_center + x * Math.Sin(angle) + y * Math.Cos(angle))));
                }

                tA.Text = Convert.ToString(angle);
                tAgrads.Text = Convert.ToString(angle / (double)Math.PI * 180);

                draw_initial_rotate(ref bmp);
                if (cboxRotateCurve.Checked)
                    draw();

                Graphics g = Graphics.FromImage(bmp);
                g.DrawLine(rotate_pen, point_on_circle(coords, (int)(circle_radius * .5)), point_on_circle(coords, circle_radius));

                pbox.Image = bmp;
            }
            else
                if (zoom)
                {
                    bmp = new Bitmap(x_size, y_size);

                    double mx = Mx(x_zoom, mouse_events.Location);
                    double my = My(y_zoom, mouse_events.Location);

                    for (int i = 0; i < fixed_points.Count; i++)
                    {
                        int x = (int)((fixed_points[i].X - x_center) * mx + x_center);
                        int y = (int)((fixed_points[i].Y - y_center) * my + y_center);
                        points[i] = new Point(x, y);
                    }

                    draw_zoom_lines(bmp, mouse_events.Location);
                    draw_points(points, bmp);
                    if (cboxZoomCurve.Checked)
                        draw();

                    tXZoom.Text = Convert.ToString(mx);
                    tYZoom.Text = Convert.ToString(my);

                    pbox.Image = bmp;
                }
                else
                    if (move)
                    {
                        bmp = new Bitmap(x_size, y_size);

                        int dx = mouse_events.X - move_center.X;
                        int dy = mouse_events.Y - move_center.Y + 300;

                        bool let_X = true;
                        bool let_Y = true;
                        for (int i = 0; i < points_from_center.Count; i++)
                        {
                            int x = points_from_center[i].X + mouse_events.X;
                            int y = points_from_center[i].Y + mouse_events.Y + 300;

                            if (x < point_size || x_size - point_size <= x)
                                let_X = false;
                            if (y < 300 + point_size || 700 - point_size <= y)
                                let_Y = false;
                        }

                        for (int i = 0; i < points.Count; i++)
                        {

                            int x = points[i].X;
                            int y = points[i].Y;
                            if (let_X)
                                x = points_from_center[i].X + mouse_events.X;
                            if (let_Y)
                                y = points_from_center[i].Y + mouse_events.Y + 300;

                            points[i] = new Point(x, y);
                        }

                        draw_move_lines(bmp);
                        draw_points(points, bmp);
                        if (cboxMoveCurve.Checked)
                            draw();

                        tDX.Text = Convert.ToString(dx);
                        tDY.Text = Convert.ToString(dy);

                        pbox.Image = bmp;
                    }
        }

        void draw_zoom_lines(Bitmap bmp, Point cursor_location)
        {
            Graphics g = Graphics.FromImage(bmp);
            g.DrawLine(zoom_pen, zoom_lines_offset, cursor_location.Y + 300 - zoom_lines_half_len, zoom_lines_offset, cursor_location.Y + 300 + zoom_lines_half_len);
            g.DrawLine(zoom_pen, cursor_location.X - zoom_lines_half_len, 700 - zoom_lines_offset, cursor_location.X + zoom_lines_half_len, 700 - zoom_lines_offset);
        }

        private void bZoom_Click(object sender, EventArgs e)
        {
            zoom = true;
            fixed_points = new List<Point>(points);

            x_zoom = max_x_zoom(fixed_points);
            y_zoom = max_y_zoom(fixed_points);
            tXZoom.Text = Convert.ToString(x_zoom);
            tYZoom.Text = Convert.ToString(y_zoom);

            lXZoom.Enabled = true;
            lYZoom.Enabled = true;
            tXZoom.Enabled = true;
            tYZoom.Enabled = true;
            cboxZoomCurve.Enabled = true;
        }

        double max_x_zoom(List<Point> points)
        {
            int max_coordinate = points[0].X;
            int min_coordinate = points[0].X;

            for (int i = 1; i < points.Count; i++)
            {
                if (points[i].X < min_coordinate)
                    min_coordinate = points[i].X;
                if (max_coordinate < points[i].X)
                    max_coordinate = points[i].X;
            }

            double x = Math.Max(max_coordinate, x_size - min_coordinate);
            return (x_size - 1 - x_center) / (double)(x - x_center);
        }

        double max_y_zoom(List<Point> points)
        {
            int max_coordinate = points[0].Y;
            int min_coordinate = points[0].Y;

            for (int i = 1; i < points.Count; i++)
            {
                if (points[i].Y < min_coordinate)
                    min_coordinate = points[i].Y;
                if (max_coordinate < points[i].Y)
                    max_coordinate = points[i].Y;
            }

            double y = Math.Max(max_coordinate, x_size - min_coordinate) - 300;
            return (400 - 1 - 200) / (double)(y - 200);
        }

        double Mx(double x_zoom, Point cursor_location)
        {
            return x_zoom - x_zoom * (x_size - cursor_location.X) / (double)x_size;
        }

        double My(double y_zoom, Point cursor_location)
        {
            return y_zoom - y_zoom * (400 - (cursor_location.Y)) / (double)400;
        }

        private void bMove_Click(object sender, EventArgs e)
        {
            move = true;
            move_center = calculate_center_figure(points);

            points_from_center = new List<Point>();
            for (int i = 0; i < points.Count; i++)
                points_from_center.Add(new Point(points[i].X - move_center.X, points[i].Y - move_center.Y));

            draw_move_lines(bmp);
            draw_points(points, bmp);
            pbox.Image = bmp;

            tDX.Enabled = true;
            tDY.Enabled = true;
            lDX.Enabled = true;
            lDY.Enabled = true;
            cboxMoveCurve.Enabled = true;
        }

        Point calculate_move_center(List<Point> points)
        {
            return new Point(max_coordinate_X(points) - min_coordinate_X(points), max_coordinate_Y(points) - min_coordinate_Y(points));
        }

        Point calculate_center_figure(List<Point> points)
        {
            int center_X = 0;
            int center_Y = 0;
            for (int i = 0; i < points.Count; i++)
            {
                center_X += points[i].X;
                center_Y += points[i].Y;
            }
            return new Point(center_X / points.Count, center_Y / points.Count);
        }

        int min_coordinate_X(List<Point> points)
        {
            int min_coordinate_x = points[0].X;
            for (int i = 1; i < points.Count; i++)
                if (points[i].X < min_coordinate_x)
                    min_coordinate_x = points[i].X;
            return min_coordinate_x;
        }

        int max_coordinate_X(List<Point> points)
        {
            int max_coordinate_x = points[0].X;
            for (int i = 1; i < points.Count; i++)
                if (max_coordinate_x < points[i].X)
                    max_coordinate_x = points[i].X;
            return max_coordinate_x;
        }

        int min_coordinate_Y(List<Point> points)
        {
            int min_coordinate_y = points[0].Y;
            for (int i = 1; i < points.Count; i++)
                if (points[i].Y < min_coordinate_y)
                    min_coordinate_y = points[i].Y;
            return min_coordinate_y;
        }

        int max_coordinate_Y(List<Point> points)
        {
            int max_coordinate_y = points[0].Y;
            for (int i = 1; i < points.Count; i++)
                if (max_coordinate_y < points[i].Y)
                    max_coordinate_y = points[i].Y;
            return max_coordinate_y;
        }

        void draw_move_lines(Bitmap bmp)
        {
            Graphics g = Graphics.FromImage(bmp);
            g.DrawLine(move_pen, move_lines_offset, min_coordinate_Y(points), move_lines_offset, max_coordinate_Y(points));
            g.DrawLine(move_pen, min_coordinate_X(points), 700 - zoom_lines_offset, max_coordinate_X(points), 700 - zoom_lines_offset);
        }

        bool can_move(List<Point> points)
        {
            for (int i = 0; i < points.Count; i++)
                if (points[i].X < point_size || x_size - point_size <= points[i].X || points[i].Y < 0 + 300 + point_size || y_size - 300 - point_size <= points[i].Y)
                    return false;
            return true;
        }

        bool can_move_X(List<Point> points)
        {
            for (int i = 0; i < points.Count; i++)
                if (points[i].X < point_size || x_size - 2 - point_size <= points[i].X)
                    return false;
            return true;
        }
        bool can_move_Y(List<Point> points)
        {
            for (int i = 0; i < points.Count; i++)
                if (points[i].Y < 0 + 300 + point_size || y_size - 300 - point_size <= points[i].Y)
                    return false;
            return true;
        }

        int x_correction(List<Point> points)
        {
            int corr = 0;
            for (int i = 0; i < points.Count; i++)
                if (points[i].X < 0 && corr < -points[i].X)
                    corr = points[i].X;
                else
                    if (x_size <= points[i].X && corr <= points[i].X - x_size)
                        corr = points[i].X - x_size;
            return corr;
        }
    }
}

