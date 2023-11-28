using System;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using EntityWorkers.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityWorkers
{
    public partial class Form1 : Form
    {
        private MyDbContext dbContext;

        public Form1()
        {
            InitializeComponent();
            dbContext = new MyDbContext();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            var workersData = dbContext.Workers
                .Select(worker => new
                {
                    Id = worker.Id,
                    Name = worker.Name,
                    Age = worker.Age,
                    City = worker.WorkersCityCity,
                    Country = worker.WorkersCountryCountry
                })
                .ToList();

            dataGridView1.DataSource = workersData;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string age = txtAge.Text;
            string city = txtCity.Text;
            string country = txtCountry.Text;

            Worker newWorker = new Worker
            {
                Name = name,
                Age = age,
                WorkersCityCity = city,
                WorkersCountryCountry = country
            };

            dbContext.Workers.Add(newWorker);
            dbContext.SaveChanges();

            InitializeDataGridView();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                int workerId = (int)dataGridView1.Rows[selectedRowIndex].Cells["Id"].Value;

                Worker selectedWorker = dbContext.Workers.Find(workerId);

                selectedWorker.Name = txtName.Text;
                selectedWorker.Age = txtAge.Text;
                selectedWorker.WorkersCityCity = txtCity.Text;
                selectedWorker.WorkersCountryCountry = txtCountry.Text;

                dbContext.SaveChanges();

                InitializeDataGridView();
            }
            else
            {
                MessageBox.Show("Please select a row to update.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                int workerId = (int)dataGridView1.Rows[selectedRowIndex].Cells["Id"].Value;

                Worker selectedWorker = dbContext.Workers.Find(workerId);

                dbContext.Workers.Remove(selectedWorker);
                dbContext.SaveChanges();

                InitializeDataGridView();
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }
        private void FilterWorkersByCity()
        {
            var selectedData = dbContext.Workers
                .Select(worker => new
                {
                    Id = worker.Id,
                    Name = worker.Name,
                    City = worker.WorkersCityCity
                })
                .ToList();

            dataGridView1.DataSource = selectedData;
        }

        private void SortWorkersByAge()
        {
            var sortedWorkers = dbContext.Workers.Select(worker => new
            {
                Id = worker.Id,
                Name = worker.Name,
                Age = worker.Age,
                City = worker.WorkersCityCity,
                Country = worker.WorkersCountryCountry
            })
                .OrderBy(worker => worker.Age)
                .ToList();

            dataGridView1.DataSource = sortedWorkers;
        }

        private void SelectNameAndCountry()
        {
            var selectedData = dbContext.Workers
                .Select(worker => new
                {
                    Id = worker.Id,
                    Name = worker.Name,
                    Country = worker.WorkersCountryCountry
                })
                .ToList();

            dataGridView1.DataSource = selectedData;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SortWorkersByAge();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FilterWorkersByCity();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SelectNameAndCountry();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string cityName = cityNameBox.Text;

            if (!string.IsNullOrEmpty(cityName))
            {
                WorkersCity cityToDelete = dbContext.WorkersCities.FirstOrDefault(city => city.City == cityName);

                if (cityToDelete != null)
                {
                    dbContext.WorkersCities.Remove(cityToDelete);

                    dbContext.SaveChanges();

                    InitializeDataGridView();

                    MessageBox.Show($"Workers associated with the city '{cityName}' have been deleted.");
                }
                else
                {
                    MessageBox.Show($"City with name '{cityName}' not found.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a city name.");
            }
        }
    }
}
